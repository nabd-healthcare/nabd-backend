namespace Nabd.Application.DTOs.Responses.Diagnosis;

/// <summary>
/// Response DTO for diagnosis feature
/// Returns normalized symptoms and AI-suggested diagnosis
/// </summary>
public class DiagnosisResponseDto
{
    /// <summary>
    /// Patient identifier
    /// </summary>
    public string PatientId { get; set; } = string.Empty;

    /// <summary>
    /// Original symptoms text as entered by doctor
    /// </summary>
    public string OriginalSymptoms { get; set; } = string.Empty;

    /// <summary>
    /// Normalized symptoms list (extracted and standardized by AI)
    /// Will be null until AI integration is complete
    /// </summary>
    public List<string>? NormalizedSymptoms { get; set; }

    /// <summary>
    /// AI-suggested diagnosis based on symptoms (Top 1)
    /// </summary>
    public string SuggestedDiagnosis { get; set; } = string.Empty;

    /// <summary>
    /// Top 3 AI-suggested diagnoses with confidences
    /// </summary>
    public List<AiDiagnosisResultDto>? TopResults { get; set; }

    /// <summary>
    /// Confidence level of the primary diagnosis (0-100)
    /// </summary>
    public int? ConfidenceLevel { get; set; }

    /// <summary>
    /// Timestamp when diagnosis was generated
    /// </summary>
    public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
}

/// <summary>
/// Individual result from AI model with detailed medical information
/// </summary>
public record AiDiagnosisResultDto(
    string Disease, 
    double Confidence, 
    string? NameAr = null, 
    string? DescriptionAr = null, 
    List<string>? PrecautionsAr = null
);
