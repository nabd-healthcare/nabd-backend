using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nabd.Core.Entities.Common;
using Nabd.Core.Entities.External.Clinic;
using Nabd.Core.Entities.Medical.Consultations;
using Nabd.Core.Entities.Medical.Schedules;

using Nabd.Core.Entities.System.Review;
using Nabd.Core.Enums.Doctor;
using Nabd.Core.Enums.Identity;
using Nabd.Core.Entities.Medical;

namespace Nabd.Core.Entities.Identity
{
    public class Doctor : ProfileUser
    {
        public MedicalSpecialty MedicalSpecialty { get; set; }
        public int YearsOfExperience { get; set; }
		public string? Biography { get; set; }

        // Verification
        public VerificationStatus VerificationStatus { get; set; } = VerificationStatus.Unverified;
        public DateTime? VerifiedAt { get; set; }

        [ForeignKey("Verifier")]
        public Guid? VerifierId { get; set; }

        // Navigation Properties
        public virtual Verifier? Verifier { get; set; }
        public virtual Clinic? Clinic { get; set; }

		public virtual ICollection<DoctorConsultation> Consultations { get; set; } = new HashSet<DoctorConsultation>();
		public virtual ICollection<DoctorOverride> Overrides { get; set; } = new HashSet<DoctorOverride>();
        public virtual ICollection<DoctorAvailability> Availabilities { get; set; } = new HashSet<DoctorAvailability>();
        public virtual ICollection<DoctorDocument> VerificationDocuments { get; set; } = new HashSet<DoctorDocument>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
        public virtual ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
		public virtual ICollection<DoctorReview> DoctorReviews { get; set; } = new HashSet<DoctorReview>();

		[NotMapped]
		public double? AverageRating { get; set; }

		[NotMapped]
		public int TotalReviewsCount { get; set; }
	}
}