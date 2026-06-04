using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nabd.Core.Entities.Base;
using Nabd.Core.Entities.Identity;

namespace Nabd.Core.Entities.Medical
{
    public class DispensingRecord : AuditableEntity
    {
        [ForeignKey("PrescribedMedication")]
        public Guid PrescribedMedicationId { get; set; }

        [ForeignKey("Patient")]
        public Guid PatientId { get; set; }

        public DateTime DispensedDate { get; set; }

        public int QuantityDispensed { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }

        [MaxLength(200)]
        public string? DispensedBy { get; set; }

        // Navigation Properties
        public virtual PrescribedMedication PrescribedMedication { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
    }
}
