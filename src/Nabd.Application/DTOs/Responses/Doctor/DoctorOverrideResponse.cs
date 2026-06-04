using Nabd.Application.DTOs.Common.Base;
using Nabd.Core.Enums.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nabd.Application.DTOs.Responses.Doctor
{
    public class DoctorOverrideResponse : BaseAuditableDto
    {
        public Guid DoctorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public OverrideType Type { get; set; }
    }
}
