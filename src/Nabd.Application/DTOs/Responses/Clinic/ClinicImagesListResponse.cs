using System.Collections.Generic;

namespace Nabd.Application.DTOs.Responses.Clinic
{
    public class ClinicImagesListResponse
    {
        public List<ClinicImageResponse> Images { get; set; } = new List<ClinicImageResponse>();
    }
}
