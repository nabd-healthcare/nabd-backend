using Nabd.Application.DTOs.Common.Base;
using Nabd.Core.Enums.Doctor;
using Nabd.Core.Enums.Identity;
using System;

namespace Nabd.Application.DTOs.Responses.Doctor
{
    public class DoctorProfileResponse : BaseAuditableDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? ProfilePictureUrl { get; set; }
        public Gender Gender { get; set; }
        public string GenderName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public MedicalSpecialty MedicalSpecialty { get; set; }
        public string MedicalSpecialtyName { get; set; } = string.Empty;
        public string? Biography { get; set; }
        

        // Verification
        public VerificationStatus VerificationStatus { get; set; }
        public string VerificationStatusName { get; set; } = string.Empty;
    }
}
