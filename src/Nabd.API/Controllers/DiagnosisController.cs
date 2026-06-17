using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nabd.Application.DTOs.Requests.Diagnosis;
using Nabd.Application.DTOs.Responses.Diagnosis;
using Nabd.Application.Interfaces;
using System.Security.Claims;

namespace Nabd.API.Controllers;

/// <summary>
/// Controller for AI-powered diagnosis feature
/// Allows doctors to get preliminary diagnosis based on patient symptoms
/// </summary>
[ApiController]
[Route("api/doctor/[controller]")]
[Authorize(Roles = "Doctor")] // Only doctors can access diagnosis feature
public class DiagnosisController : ControllerBase
{
    private readonly IDiagnosisService _diagnosisService;
    private readonly ILogger<DiagnosisController> _logger;

    public DiagnosisController(
        IDiagnosisService diagnosisService,
        ILogger<DiagnosisController> logger)
    {
        _diagnosisService = diagnosisService;
        _logger = logger;
    }

    /// <summary>
    /// Process diagnosis request and get AI-suggested diagnosis
    /// </summary>
    /// <param name="request">Diagnosis request containing patient ID and symptoms</param>
    /// <returns>Diagnosis response with normalized symptoms and suggested diagnosis</returns>
    /// <response code="200">Returns the diagnosis response</response>
    /// <response code="400">If the request is invalid</response>
    /// <response code="401">If the user is not authenticated</response>
    /// <response code="403">If the user is not a doctor</response>
    [HttpPost]
    [ProducesResponseType(typeof(DiagnosisResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Diagnose([FromBody] DiagnosisRequestDto request)
    {
        try
        {
            // Validate request
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid diagnosis request received");
                return BadRequest(ModelState);
            }

            // Validate symptoms or evidence codes
            if (string.IsNullOrWhiteSpace(request.SymptomsText) && (request.EvidenceCodes == null || !request.EvidenceCodes.Any()))
            {
                _logger.LogWarning("Empty symptoms and evidence codes received");
                return BadRequest(new { error = "Either symptoms text or evidence codes must be provided" });
            }

            // Get current doctor ID from claims
            var doctorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(doctorId))
            {
                _logger.LogWarning("Doctor ID not found in claims");
                return Unauthorized(new { error = "Doctor authentication required" });
            }

            _logger.LogInformation("Doctor {DoctorId} requesting diagnosis for patient {PatientId}", 
                doctorId, request.PatientId);

            // Process diagnosis
            var response = await _diagnosisService.ProcessDiagnosisAsync(request);

            _logger.LogInformation("Diagnosis completed successfully for patient {PatientId}", 
                request.PatientId);

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing diagnosis request");
            return StatusCode(500, new 
            { 
                error = "An error occurred while processing the diagnosis",
                message = "Please try again or contact support if the problem persists"
            });
        }
    }

    /// <summary>
    /// Health check endpoint for diagnosis service
    /// </summary>
    /// <returns>Service status</returns>
    [HttpGet("health")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult HealthCheck()
    {
        return Ok(new 
        { 
            status = "healthy",
            service = "diagnosis",
            timestamp = DateTime.UtcNow,
            aiIntegration = "active-local", // Local TensorFlow model via Python
            modelType = "TensorFlow/Keras",
            executionMode = "Python Subprocess"
        });
    }

    /// <summary>
    /// Get all available evidence codes and their English names for the symptom search autocomplete.
    /// This reads directly from evidences.json so the frontend always shows EVERY symptom the model knows.
    /// </summary>
    /// <returns>List of { code, name } objects</returns>
    [HttpGet("evidences")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetEvidences()
    {
        try
        {
            var evidences = await _diagnosisService.GetEvidencesAsync();

            // Return as array of { code, name } for easy consumption by frontend
            var result = evidences
                .Select(kvp => new { code = kvp.Key, name = kvp.Value })
                .OrderBy(e => e.code)
                .ToList();

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching evidences list");
            return StatusCode(500, new { error = "Failed to load evidences" });
        }
    }
}
