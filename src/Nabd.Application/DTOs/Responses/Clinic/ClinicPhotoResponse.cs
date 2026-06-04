using Nabd.Application.DTOs.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nabd.Application.DTOs.Responses.Clinic
{
    public class ClinicPhotoResponse : BaseAuditableDto
    {
        public string PhotoUrl { get; set; } = string.Empty;
        public string? Caption { get; set; }
        public Guid ClinicId { get; set; }
    }
}
