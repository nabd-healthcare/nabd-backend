using System;

namespace Nabd.Application.DTOs.Responses.Clinic
{
    public class ClinicImageResponse
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public int Order { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
