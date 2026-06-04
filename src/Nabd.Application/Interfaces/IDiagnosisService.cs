using Nabd.Application.DTOs.Requests.Diagnosis;
using Nabd.Application.DTOs.Responses.Diagnosis;

namespace Nabd.Application.Interfaces;

/// <summary>
/// Service interface for AI-powered diagnosis feature
/// </summary>
public interface IDiagnosisService
{
    /// <summary>
    /// Process diagnosis request by normalizing symptoms and generating AI diagnosis
    /// </summary>
    /// <param name="request">Diagnosis request containing patient ID and symptoms</param>
    /// <returns>Diagnosis response with normalized symptoms and suggested diagnosis</returns>
    Task<DiagnosisResponseDto> ProcessDiagnosisAsync(DiagnosisRequestDto request);
}
