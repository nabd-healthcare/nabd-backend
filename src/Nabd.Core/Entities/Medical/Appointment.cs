using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nabd.Core.Entities.Base;
using Nabd.Core.Entities.Identity;
using Nabd.Core.Entities.Medical.Consultations;
using Nabd.Core.Entities.System.Review;
using Nabd.Core.Enums.Appointments;

namespace Nabd.Core.Entities.Medical
{
    public class Appointment : AuditableEntity
	{
        [ForeignKey("Patient")]
        public Guid PatientId { get; set; }
        [ForeignKey("Doctor")]
        public Guid DoctorId { get; set; }

        [ForeignKey("PreviousAppointment")]
        public Guid? PreviousAppointmentId { get; set; }

        public DateTime ScheduledStartTime { get; set; }
        public DateTime ScheduledEndTime { get; set; }
        public ConsultationTypeEnum ConsultationType { get; set; }
        public decimal ConsultationFee { get; set; }
        public int SessionDurationMinutes { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Confirmed;
        public string? CancellationReason { get; set; }
        public DateTime? CancelledAt { get; set; }
        public DateTime? ActualStartTime { get; set; }
        public DateTime? ActualEndTime { get; set; }

        // Navigation Properties
        public virtual Patient Patient { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Prescription? Prescription { get; set; }
        public virtual ConsultationRecord? ConsultationRecord { get; set; }
        public virtual Appointment? PreviousAppointment { get; set; }
        public virtual ICollection<Appointment> FollowUpAppointments { get; set; } = new HashSet<Appointment>();
		public virtual DoctorReview? DoctorReview { get; set; }

	}
}
