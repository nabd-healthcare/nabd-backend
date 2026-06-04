using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nabd.Core.Entities.Base;

namespace Nabd.Core.Entities.Medical
{
    public class Medication : AuditableEntity
    {
        [MaxLength(200)]
        public string BrandName { get; set; } = string.Empty;

        [MaxLength(200)]
        public string GenericName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Strength { get; set; }

        [MaxLength(100)]
        public string? DosageForm { get; set; }

        [MaxLength(100)]
        public string? Manufacturer { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        public bool RequiresPrescription { get; set; } = true;

        // Navigation Properties
        public virtual ICollection<PrescribedMedication> PrescribedMedications { get; set; } = new HashSet<PrescribedMedication>();
    }
}
