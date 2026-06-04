using Nabd.Application.DTOs.Common.Base;
using Nabd.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nabd.Application.DTOs.Responses.Doctor
{
    public class DoctorAvailabilityResponse : BaseSoftDeletableDto
    {
        public Guid DoctorId { get; set; }
        public SysDayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}

