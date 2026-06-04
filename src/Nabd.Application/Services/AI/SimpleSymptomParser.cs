using Microsoft.Extensions.Logging;
using Nabd.Application.Interfaces;

namespace Nabd.Application.Services.AI;

/// <summary>
/// Simplified symptom parser that just splits the input text.
/// All intelligence (mapping, normalization) is now handled at the Python/Model layer.
/// </summary>
public class SimpleSymptomParser : IArabicSymptomParser
{
    private readonly ILogger<SimpleSymptomParser> _logger;

    public SimpleSymptomParser(ILogger<SimpleSymptomParser> logger)
    {
        _logger = logger;
    }

    public Task<List<string>> ParseSymptomsAsync(string text)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(text)) 
                return Task.FromResult(new List<string>());

            // Basic split by comma, semicolon, or newline
            var rawSymptoms = text
                .Split(new[] { ',', ';', '،', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrEmpty(s))
                .ToList();

            _logger.LogInformation("Symptoms split into {Count} raw items.", rawSymptoms.Count);
            return Task.FromResult(rawSymptoms);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in SimpleSymptomParser");
            return Task.FromResult(new List<string>());
        }
    }
}
