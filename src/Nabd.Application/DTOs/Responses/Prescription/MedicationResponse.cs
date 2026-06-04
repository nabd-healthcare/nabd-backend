using Nabd.Application.DTOs.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nabd.Application.DTOs.Responses.Prescription
{
    public class MedicationResponse : BaseAuditableDto
    {
        public string BrandName { get; set; } = string.Empty;
        public string? GenericName { get; set; }
        public string? Strength { get; set; }
        public string DosageForm { get; set; } = string.Empty;
    }
}
