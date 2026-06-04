using System.Text.RegularExpressions;

namespace Nabd.Application.Services.AI;

public static class CanonicalSymptomNormalizer
{
    public static string Normalize(string symptom)
    {
        if (string.IsNullOrWhiteSpace(symptom)) return string.Empty;

        // 1. ToLowerCase & Trim
        var normalized = symptom.ToLowerInvariant().Trim();

        // 2. Remove extra whitespace inside (e.g. "chest    pain" -> "chest pain")
        normalized = Regex.Replace(normalized, @"\s+", " ");

        // 3. Remove non-alphanumeric chars EXCEPT spaces and underscores
        // This cleans up accidentally pasted punctuation but keeps spaces valid
        // normalized = Regex.Replace(normalized, @"[^a-z0-9_ ]", "");
        
        return normalized;
    }

    public static List<string> NormalizeList(IEnumerable<string> symptoms)
    {
        return symptoms
            .Select(Normalize)
            .Where(s => !string.IsNullOrEmpty(s))
            .ToList();
    }
}
