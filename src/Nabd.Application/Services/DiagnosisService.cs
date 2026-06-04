using Microsoft.Extensions.Logging;
using System.Text.Json;
using Nabd.Application.AI.Diagnosis;
using Nabd.Application.DTOs.Requests.Diagnosis;
using Nabd.Application.DTOs.Responses.Diagnosis;
using Nabd.Application.Interfaces;

namespace Nabd.Application.Services;

/// <summary>
/// Service implementation for AI-powered diagnosis.
/// This service acts as a simple bridge between the UI and the AI models.
/// All complex parsing and normalization are handled by the models themselves.
/// </summary>
public class DiagnosisService : IDiagnosisService
{
    private readonly ILogger<DiagnosisService> _logger;
    private readonly MainDiagnosisLocalModel _localModel;
    private readonly IArabicSymptomParser _symptomParser;

    public DiagnosisService(
        ILogger<DiagnosisService> logger,
        MainDiagnosisLocalModel localModel,
        IArabicSymptomParser symptomParser)
    {
        _logger = logger;
        _localModel = localModel;
        _symptomParser = symptomParser;
    }

    /// <summary>
    /// Process diagnosis request by parsing symptoms via selected AI model
    /// </summary>
    public async Task<DiagnosisResponseDto> ProcessDiagnosisAsync(DiagnosisRequestDto request)
    {
        try
        {
            _logger.LogInformation("Processing diagnosis for patient {PatientId} using Local Model", request.PatientId);

            List<string> rawSymptoms;
            
            // Step 1: Check if SymptomsText is a JSON object with evidence_codes
            if (!string.IsNullOrWhiteSpace(request.SymptomsText) && request.SymptomsText.Trim().StartsWith("{"))
            {
                try 
                {
                    using var doc = JsonDocument.Parse(request.SymptomsText);
                    var root = doc.RootElement;
                    
                    if (root.TryGetProperty("evidence_codes", out var codes))
                    {
                        rawSymptoms = codes.EnumerateArray().Select(c => c.GetString()!).ToList();
                        
                        // Override Age/Sex if provided in JSON
                        if (root.TryGetProperty("age", out var ageVal)) request.Age = ageVal.GetInt32();
                        if (root.TryGetProperty("sex", out var sexVal)) request.Sex = sexVal.GetString();
                        
                        _logger.LogInformation("Parsed JSON input with {Count} evidence codes", rawSymptoms.Count);
                        goto ExecuteInference;
                    }
                }
                catch (JsonException) { /* Not valid JSON, fallback to normal parser */ }
            }

            // Step 2: Check if we have direct evidence codes, otherwise parse symptoms text
            if (request.EvidenceCodes != null && request.EvidenceCodes.Any())
            {
                _logger.LogInformation("Using direct evidence codes: {Codes}", string.Join(", ", request.EvidenceCodes));
                rawSymptoms = request.EvidenceCodes;
            }
            else if (!string.IsNullOrWhiteSpace(request.SymptomsText))
            {
                // Step 3: Normal Arabic/Text Parsing
                rawSymptoms = await _symptomParser.ParseSymptomsAsync(request.SymptomsText);
                
                // Step 4: Extract Age/Sex from text and filter them out
                var ageRegex = new System.Text.RegularExpressions.Regex(@"Age:\s*(\d+)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                var sexRegex = new System.Text.RegularExpressions.Regex(@"Sex:\s*(Female|Male|M|F)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                
                var filteredSymptoms = new List<string>();
                foreach (var symptom in rawSymptoms)
                {
                    var ageMatch = ageRegex.Match(symptom);
                    var sexMatch = sexRegex.Match(symptom);
                    
                    if (ageMatch.Success)
                    {
                        if (int.TryParse(ageMatch.Groups[1].Value, out int age))
                            request.Age = age;
                        continue; // Exclude from symptom list
                    }
                    
                    if (sexMatch.Success)
                    {
                        var sexStr = sexMatch.Groups[1].Value.Trim().ToUpper();
                        request.Sex = (sexStr == "MALE" || sexStr == "M") ? "M" : "F";
                        continue; // Exclude from symptom list
                    }
                    
                    filteredSymptoms.Add(symptom);
                }
                rawSymptoms = filteredSymptoms;
                
                _logger.LogInformation("Parsed input symptoms: {Symptoms} | Overridden Age: {Age}, Sex: {Sex}", 
                    string.Join(", ", rawSymptoms), request.Age, request.Sex);
            }
            else
            {
                throw new ArgumentException("Either SymptomsText or EvidenceCodes must be provided.");
            }

        ExecuteInference:
            // Local Model handles its own mapping and normalization internally
            var results = await _localModel.DiagnoseAsync(rawSymptoms, request.Age, request.Sex);

            var primary = results.FirstOrDefault();

            // Step 2: Build and return response
            return new DiagnosisResponseDto
            {
                PatientId = request.PatientId,
                OriginalSymptoms = request.SymptomsText ?? (request.EvidenceCodes != null ? string.Join(", ", request.EvidenceCodes) : "Structured Input"),
                NormalizedSymptoms = rawSymptoms,
                SuggestedDiagnosis = primary.NameAr ?? (primary.Diagnosis ?? "Unknown"),
                ConfidenceLevel = (int)primary.Confidence,
                TopResults = results.Select(r => new AiDiagnosisResultDto(
                    r.Diagnosis, 
                    r.Confidence, 
                    r.NameAr, 
                    r.DescriptionAr, 
                    r.PrecautionsAr)).ToList(),
                GeneratedAt = DateTime.UtcNow
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing diagnosis for patient {PatientId}", request.PatientId);
            
            return new DiagnosisResponseDto
            {
                PatientId = request.PatientId,
                OriginalSymptoms = request.SymptomsText ?? "Unknown",
                NormalizedSymptoms = new List<string>(),
                SuggestedDiagnosis = "عذراً، حدث خطأ أثناء التحليل. يرجى المحاولة مرة أخرى أو الاعتماد على الفحص السريري.",
                ConfidenceLevel = 0,
                GeneratedAt = DateTime.UtcNow
            };
        }
    }
}
