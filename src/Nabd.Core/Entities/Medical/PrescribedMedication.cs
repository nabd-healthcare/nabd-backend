using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nabd.Core.Entities.Base;

namespace Nabd.Core.Entities.Medical
{
    public class PrescribedMedication : SoftDeletableEntity
    {
        [ForeignKey("Prescription")]
        public Guid MedicationPrescriptionId { get; set; }

        [ForeignKey("Medication")]
        public Guid MedicationId { get; set; }

        [MaxLength(100)]
        public string Dosage { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Frequency { get; set; } = string.Empty;

        public int DurationDays { get; set; }

        [MaxLength(500)]
        public string? SpecialInstructions { get; set; }

        // Navigation Properties
        public virtual Prescription Prescription { get; set; } = null!;
        public virtual Medication Medication { get; set; } = null!;
        public virtual ICollection<DispensingRecord> DispensingRecords { get; set; } = new HashSet<DispensingRecord>();
    }
}
