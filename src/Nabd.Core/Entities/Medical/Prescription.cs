using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nabd.Core.Entities.Base;
using Nabd.Core.Entities.Identity;
using Nabd.Core.Enums;

namespace Nabd.Core.Entities.Medical
{
    public class Prescription : AuditableEntity
    {
        [MaxLength(50)]
        public string PrescriptionNumber { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? DigitalSignature { get; set; }

        [ForeignKey("Appointment")]
        public Guid? AppointmentId { get; set; }

        [ForeignKey("Doctor")]
        public Guid DoctorId { get; set; }

        [ForeignKey("Patient")]
        public Guid PatientId { get; set; }

        [MaxLength(1000)]
        public string? GeneralInstructions { get; set; }

        public PrescriptionStatus Status { get; set; } = PrescriptionStatus.Active;

        public DateTime? DispensedAt { get; set; }

        [MaxLength(500)]
        public string? CancellationReason { get; set; }

        public DateTime? CancelledAt { get; set; }

        // Navigation Properties
        public virtual Appointment? Appointment { get; set; }
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
        public virtual ICollection<PrescribedMedication> PrescribedMedications { get; set; } = new HashSet<PrescribedMedication>();
    }
}
