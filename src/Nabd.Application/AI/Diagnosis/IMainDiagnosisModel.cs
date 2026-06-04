namespace Nabd.Application.AI.Diagnosis;

/// <summary>
/// Interface for the main diagnosis AI model
/// This model takes normalized symptoms and returns a suggested diagnosis
/// </summary>
public record AiModelResult(
    string Diagnosis, 
    double Confidence, 
    string? NameAr = null, 
    string? DescriptionAr = null, 
    List<string>? PrecautionsAr = null
);

public interface IMainDiagnosisModel
{
    /// <summary>
    /// Perform diagnosis based on normalized symptoms
    /// </summary>
    /// <returns>List of detailed AI diagnosis results</returns>
    Task<List<AiModelResult>> DiagnoseAsync(List<string> normalizedSymptoms, int? age = null, string? sex = null);
    
    /// <summary>
    /// Get list of all available symptoms that the model understands
    /// </summary>
    /// <returns>List of symptom names</returns>
    Task<List<string>> GetAvailableSymptomsAsync();
}
