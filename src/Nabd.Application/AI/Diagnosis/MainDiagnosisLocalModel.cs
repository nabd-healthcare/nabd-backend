using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;

namespace Nabd.Application.AI.Diagnosis;

/// <summary>
/// Persistent Local AI model implementation.
/// Keeps Python process alive to avoid 20s TensorFlow loading overhead per request.
/// </summary>
public class MainDiagnosisLocalModel : IMainDiagnosisModel, IDisposable
{
    private readonly ILogger<MainDiagnosisLocalModel> _logger;
    private readonly string _pythonExecutable;
    private readonly string _scriptPath;
    private readonly string _symptomColsPath;
    private List<string>? _cachedSymptoms;
    
    // Persistent Process Management
    private Process? _pythonProcess;
    private readonly SemaphoreSlim _lock = new(1, 1);
    private TaskCompletionSource<bool> _readySource = new();

    public MainDiagnosisLocalModel(ILogger<MainDiagnosisLocalModel> logger)
    {
        _logger = logger;
        _pythonExecutable = @"C:\Users\muham\AppData\Local\Programs\Python\Python312\python.exe"; 
        
        var baseDir = AppContext.BaseDirectory;
        // The project structure is Back/src/Nabd.API/bin/...
        // The target folder is Back/src/Nabd.Application/AI/Diagnosis/Data
        var aiModelsPath = Path.Combine(baseDir, "..", "..", "..", "..", "..", "src", "Nabd.Application", "AI", "Diagnosis", "Data");
        
        _scriptPath = Path.Combine(aiModelsPath, "medical_ai_service.py");
        _symptomColsPath = Path.Combine(aiModelsPath, "symptom_to_ecode.json");

        // Start process in background immediately to warm up
        Task.Run(() => EnsureProcessStarted());
    }

    private void EnsureProcessStarted()
    {
        if (_pythonProcess != null && !_pythonProcess.HasExited) return;

        // Reset the ready source
        if (_readySource.Task.IsCompleted)
        {
            _readySource = new TaskCompletionSource<bool>();
        }

        try 
        {
            _logger.LogInformation("Starting persistent Python AI process using direct Python 3.12 path...");
            
            var processStartInfo = new ProcessStartInfo
            {
                FileName = _pythonExecutable,
                Arguments = $"\"{_scriptPath}\"",
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardInputEncoding = new System.Text.UTF8Encoding(false),
                StandardOutputEncoding = new System.Text.UTF8Encoding(false),
                CreateNoWindow = true,
                WorkingDirectory = Path.GetDirectoryName(_scriptPath)
            };

            _pythonProcess = new Process { StartInfo = processStartInfo };
            _pythonProcess.Start();

            // Handle errors in background
            Task.Run(async () => {
                while (!_pythonProcess.HasExited) {
                    var err = await _pythonProcess.StandardError.ReadLineAsync();
                    if (err != null) _logger.LogWarning("AI Process Error: {Err}", err);
                }
            });

            // Wait for "READY" signal in background to not block the constructor too much
            // but we'll wait for it in DiagnoseAsync
            Task.Run(async () => {
                try {
                    while (!_pythonProcess.HasExited) {
                        var line = await _pythonProcess.StandardOutput.ReadLineAsync();
                        if (line == null) break;
                        
                        if (line.Contains("READY")) {
                            _readySource.TrySetResult(true);
                            _logger.LogInformation("AI Model loaded and ready for inference.");
                            break;
                        }
                        _logger.LogInformation("AI Startup Output: {Line}", line);
                    }
                } catch (Exception ex) {
                    _readySource.TrySetException(ex);
                }
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to start AI process");
            _readySource.TrySetResult(false);
        }
    }

    public async Task<List<AiModelResult>> DiagnoseAsync(List<string> normalizedSymptoms, int? age = null, string? sex = null)
    {
        if (_pythonProcess == null || _pythonProcess.HasExited)
        {
            EnsureProcessStarted();
        }

        // Wait for process to be READY before entering the lock
        // Use a longer timeout for the first start (110s)
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(110));
        try {
            await _readySource.Task.WaitAsync(cts.Token);
        } catch (OperationCanceledException) {
            _logger.LogWarning("AI Model took too long to load (>90s)");
            return [new AiModelResult("Model Loading Timeout", 0)];
        }

        await _lock.WaitAsync();
        try
        {
            // The python model uses the format: {"evidence_codes": [...], "age": ..., "sex": ...}
            var requestData = new
            {
                evidence_codes = normalizedSymptoms,
                age = age ?? 30, // Default age
                sex = sex ?? "M" // Default sex
            };
            
            var requestJson = JsonSerializer.Serialize(requestData);
            
            // Send input
            await _pythonProcess!.StandardInput.WriteLineAsync(requestJson);
            await _pythonProcess.StandardInput.FlushAsync();

            string? resultJson = null;
            _logger.LogInformation("Waiting for AI response for: {Input}", requestJson);

            // Read until we get a valid JSON result
            // Use a 15-second timeout for the inference itself (since model is warm)
            var timeoutCts = new CancellationTokenSource(TimeSpan.FromSeconds(15));
            var attempts = 0;
            
            try 
            {
                while (attempts < 100 && !timeoutCts.IsCancellationRequested) 
                {
                    var line = await _pythonProcess.StandardOutput.ReadLineAsync(timeoutCts.Token);
                    if (line == null) break;

                    line = line.Trim();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // Skip the READY signal if it somehow appears here
                    if (line == "READY") continue;

                    _logger.LogInformation("AI Direct Output: {Line}", line);

                    if (line.StartsWith("{") && line.EndsWith("}"))
                    {
                        resultJson = line;
                        break;
                    }
                    attempts++;
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogError("AI Inference timed out after 15s total.");
                return [new AiModelResult("Diagnosis Timeout", 0)];
            }

            if (string.IsNullOrWhiteSpace(resultJson))
            {
                 return [new AiModelResult("AI Processing Error", 0)];
            }

            using var doc = JsonDocument.Parse(resultJson);
            var root = doc.RootElement;
            
            if (root.TryGetProperty("error", out var err))
            {
                _logger.LogError("AI Error: {Err}", err.GetString());
                return [new AiModelResult("AI Model Error", 0)];
            }

            var results = new List<AiModelResult>();
            if (root.TryGetProperty("top_results", out var topResults))
            {
                foreach (var item in topResults.EnumerateArray())
                {
                    string diseaseName = item.GetProperty("disease").GetString() ?? "Unknown";
                    double confidence = item.GetProperty("confidence").GetDouble();
                    string? nameAr = item.TryGetProperty("name_ar", out var nAr) ? nAr.GetString() : null;
                    string? descAr = item.TryGetProperty("description_ar", out var dAr) ? dAr.GetString() : null;
                    List<string>? precAr = null;
                    
                    if (item.TryGetProperty("precautions_ar", out var pAr) && pAr.ValueKind == JsonValueKind.Array)
                    {
                        precAr = pAr.EnumerateArray().Select(x => x.GetString() ?? "").ToList();
                    }

                    results.Add(new AiModelResult(diseaseName, confidence, nameAr, descAr, precAr));
                }
            }
            else
            {
                string diseaseName = root.GetProperty("disease").GetString() ?? "Unknown";
                double confidence = root.GetProperty("confidence").GetDouble();
                string? nameAr = root.TryGetProperty("name_ar", out var nAr) ? nAr.GetString() : null;
                string? descAr = root.TryGetProperty("description_ar", out var dAr) ? dAr.GetString() : null;
                List<string>? precAr = null;

                if (root.TryGetProperty("precautions_ar", out var pAr) && pAr.ValueKind == JsonValueKind.Array)
                {
                    precAr = pAr.EnumerateArray().Select(x => x.GetString() ?? "").ToList();
                }

                results.Add(new AiModelResult(diseaseName, confidence, nameAr, descAr, precAr));
            }

            return results;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during inference communication");
             return [new AiModelResult("Communication Error", 0)];
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task<List<string>> GetAvailableSymptomsAsync()
    {
        // Refresh every time during development
        
        try
        {
            if (File.Exists(_symptomColsPath))
            {
                var json = await File.ReadAllTextAsync(_symptomColsPath);
                using var doc = JsonDocument.Parse(json);
                
                // symptoms_to_ecode is a dictionary where keys are the symptom text
                _cachedSymptoms = doc.RootElement.EnumerateObject()
                    .Select(p => p.Name)
                    .Where(s => !string.IsNullOrEmpty(s))
                    .ToList();
                    
                return _cachedSymptoms;
            }
            return new List<string> { "fever", "cough" }; // minimal fallback
        }
        catch (Exception ex)
        {
             _logger.LogError(ex, "Error loading symptoms");
             return new List<string>();
        }
    }

    public void Dispose()
    {
        try 
        { 
            _pythonProcess?.StandardInput.WriteLine("EXIT"); 
            _pythonProcess?.WaitForExit(1000);
            _pythonProcess?.Kill();
            _pythonProcess?.Dispose(); 
        } 
        catch {}
        _lock.Dispose();
    }
}
