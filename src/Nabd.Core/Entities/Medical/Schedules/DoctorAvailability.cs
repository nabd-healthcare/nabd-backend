using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nabd.Core.Entities.Base;
using Nabd.Core.Entities.Identity;
using Nabd.Core.Enums;

namespace Nabd.Core.Entities.Medical.Schedules
{
    public class DoctorAvailability : SoftDeletableEntity
    {

        [ForeignKey("Doctor")]
        public Guid DoctorId { get; set; }

        public SysDayOfWeek DayOfWeek { get; set; }

        // We use TimeOnly to store only the time part
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        // Navigation Properties
        public virtual Doctor Doctor { get; set; } = null!;
    }
}
