using System.ComponentModel.DataAnnotations;

namespace Nabd.Application.DTOs.Requests.Diagnosis;

/// <summary>
/// Request DTO for diagnosis feature
/// Doctor sends symptoms text and patient id for AI-powered diagnosis
/// </summary>
public class DiagnosisRequestDto
{
    /// <summary>
    /// Patient identifier
    /// </summary>
    [Required(ErrorMessage = "Patient ID is required")]
    public string PatientId { get; set; } = string.Empty;

    /// <summary>
    /// Symptoms text in Arabic or English (will be normalized by AI)
    /// </summary>
    public string? SymptomsText { get; set; }

    /// <summary>
    /// List of direct E-codes (e.g. E_91, E_167) if available
    /// </summary>
    public List<string>? EvidenceCodes { get; set; }

    /// <summary>
    /// Patient age for the AI model
    /// </summary>
    public int? Age { get; set; }

    /// <summary>
    /// Patient sex (M/F) for the AI model
    /// </summary>
    public string? Sex { get; set; }
}
