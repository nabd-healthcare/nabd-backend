using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nabd.Core.Entities.Base;
using Nabd.Core.Entities.Identity;

namespace Nabd.Core.Entities.Medical.Consultations
{
    public class DoctorConsultation : AuditableEntity
	{
        public decimal ConsultationFee { get; set; }
        public int SessionDurationMinutes { get; set; }

        [ForeignKey("Doctor")]
        public Guid DoctorId { get; set; }

        [ForeignKey("ConsultationType")]
        public Guid ConsultationTypeId { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;
        public virtual ConsultationType ConsultationType { get; set; } = null!;
    }
}
