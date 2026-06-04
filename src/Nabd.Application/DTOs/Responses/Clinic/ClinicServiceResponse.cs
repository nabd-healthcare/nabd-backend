using Nabd.Application.DTOs.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nabd.Application.DTOs.Responses.Clinic
{
    public class ClinicServiceResponse : BaseAuditableDto
    {
        public string ServiceName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid ClinicId { get; set; }
    }
}
