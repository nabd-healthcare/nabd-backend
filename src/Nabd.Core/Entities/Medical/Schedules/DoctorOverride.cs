using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nabd.Core.Entities.Base;
using Nabd.Core.Entities.Identity;
using Nabd.Core.Enums.Appointments;

namespace Nabd.Core.Entities.Medical.Schedules
{
    public class DoctorOverride : AuditableEntity
	{

        [ForeignKey("Doctor")]
        public Guid DoctorId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public OverrideType Type { get; set; }

        // Navigation Properties
        public virtual Doctor Doctor { get; set; } = null!;
    }
}