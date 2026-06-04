using Nabd.Core.Entities.Common;
using Nabd.Core.Entities.Medical;
using Nabd.Core.Entities.Shared;
using Nabd.Core.Entities.System.Review;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nabd.Core.Entities.Identity
{
    public class Patient : ProfileUser
    {
        [ForeignKey("Address")]
        public Guid? AddressId { get; set; }

        // Navigation Properties
        public virtual Address? Address { get; set; }
        public virtual ICollection<MedicalHistoryItem> MedicalHistory { get; set; } = new HashSet<MedicalHistoryItem>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
        public virtual ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
		public virtual ICollection<DoctorReview> DoctorReviews { get; set; } = new HashSet<DoctorReview>();


	}
}
