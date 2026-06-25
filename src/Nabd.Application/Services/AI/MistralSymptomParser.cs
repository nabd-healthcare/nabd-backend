using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nabd.Application.Interfaces;

namespace Nabd.Application.Services.AI;

/// <summary>
/// Mistral-powered symptom parser.
/// Sends the doctor's free-text clinical notes to Mistral AI which:
///   1. Understands Arabic/English/mixed text
///   2. Extracts meaningful symptoms
///   3. Maps them ONLY to E-codes that exist in the model's evidence dictionary
/// This replaces SimpleSymptomParser when Mistral API key is configured.
/// </summary>
public class MistralSymptomParser : IArabicSymptomParser
{
    private readonly ILogger<MistralSymptomParser> _logger;
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _model;

    // All valid E-codes the main diagnosis model understands (loaded once at startup)
    private static readonly Lazy<string> _validCodesJson = new(() =>
    {
        // Load ecode_to_name.json at startup for the system prompt
        var baseDir = AppContext.BaseDirectory;
        var aiPath = Path.Combine(baseDir, "ai");

        // Fallback for local development
        if (!Directory.Exists(aiPath) &&
            System.Runtime.InteropServices.RuntimeInformation
                .IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
        {
            var devPath = Path.GetFullPath(Path.Combine(
                baseDir, "..", "..", "..", "..", "..", "src",
                "Nabd.Application", "AI", "Diagnosis", "Data"));
            if (Directory.Exists(devPath)) aiPath = devPath;
        }

        var ecodeFile = Path.Combine(aiPath, "ecode_to_name.json");
        if (File.Exists(ecodeFile))
            return File.ReadAllText(ecodeFile);

        return "{}";
    });

    public MistralSymptomParser(
        ILogger<MistralSymptomParser> logger,
        IConfiguration configuration,
        IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _apiKey = configuration["Mistral:ApiKey"] ?? "";
        _model  = configuration["Mistral:Model"] ?? "mistral-small-latest";
        _httpClient = httpClientFactory.CreateClient("Mistral");
        _httpClient.BaseAddress = new Uri("https://api.mistral.ai/v1/");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
    }

    public async Task<List<string>> ParseSymptomsAsync(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return [];

        // If Mistral API key is not configured, fall back gracefully
        if (string.IsNullOrWhiteSpace(_apiKey))
        {
            _logger.LogWarning("Mistral API key not configured. Falling back to raw text split.");
            return text
                .Split(new[] { ',', ';', '،', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrEmpty(s))
                .ToList();
        }

        try
        {
            var systemPrompt = BuildSystemPrompt();
            var requestBody = new
            {
                model = _model,
                response_format = new { type = "json_object" },
                temperature = 0.0, // Zero temperature = deterministic, no hallucinations
                max_tokens = 512,
                messages = new[]
                {
                    new { role = "system", content = systemPrompt },
                    new { role = "user",   content = text }
                }
            };

            var json = JsonSerializer.Serialize(requestBody);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");

            _logger.LogInformation("Sending clinical note to Mistral for symptom extraction. Text length: {Len}", text.Length);

            using var response = await _httpClient.PostAsync("chat/completions", content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseJson);

            // Extract the content from choices[0].message.content
            var messageContent = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString() ?? "{}";

            _logger.LogInformation("Mistral response: {Response}", messageContent);

            // Parse the JSON response to get matched_codes
            using var resultDoc = JsonDocument.Parse(messageContent);
            var root = resultDoc.RootElement;

            if (!root.TryGetProperty("matched_codes", out var codesEl))
            {
                _logger.LogWarning("Mistral response did not contain 'matched_codes'. Response: {R}", messageContent);
                return [];
            }

            var codes = codesEl
                .EnumerateArray()
                .Select(c => c.GetString()?.Trim())
                .Where(c => !string.IsNullOrEmpty(c) && c!.StartsWith("E_"))
                .Cast<string>()
                .Distinct()
                .ToList();

            _logger.LogInformation("Mistral extracted {Count} valid E-codes: {Codes}", codes.Count, string.Join(", ", codes));
            return codes;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error calling Mistral API for symptom extraction. Returning empty list.");
            return [];
        }
    }

    private static string BuildSystemPrompt()
    {
        return
            "You are a precise medical AI assistant integrated into the \"Nabd\" healthcare system.\n\n" +
            "Your ONLY task:\n" +
            "- Read the doctor's clinical note (may be in Arabic, English, or mixed)\n" +
            "- Identify symptoms, conditions, and medical history mentioned\n" +
            "- Match them STRICTLY to the allowed evidence codes listed below\n" +
            "- Return ONLY codes that genuinely match what the doctor described\n" +
            "- If something mentioned has NO match in the list, IGNORE it completely\n" +
            "- Do NOT invent or guess codes\n\n" +
            "ALLOWED EVIDENCE CODES (JSON dictionary of code → description):\n" +
            _validCodesJson.Value + "\n\n" +
            "OUTPUT FORMAT (strict JSON, nothing else):\n" +
            "{\"matched_codes\": [\"E_XX\", \"E_YY\", ...]}\n\n" +
            "If no symptoms match at all, return: {\"matched_codes\": []}";
    }
}
