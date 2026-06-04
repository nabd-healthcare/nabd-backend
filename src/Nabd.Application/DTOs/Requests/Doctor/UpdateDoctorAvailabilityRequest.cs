using Nabd.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nabd.Application.DTOs.Requests.Doctor
{
    public class UpdateDoctorAvailabilityRequest
    {
        public SysDayOfWeek? DayOfWeek { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }
    }
}
