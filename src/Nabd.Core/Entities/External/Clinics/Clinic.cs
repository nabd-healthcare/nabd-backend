using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nabd.Core.Entities.Base;
using Nabd.Core.Entities.Common;
using Nabd.Core.Entities.Identity;
using Nabd.Core.Entities.Shared;
using Nabd.Core.Enums;
using Nabd.Core.Enums.Identity;

namespace Nabd.Core.Entities.External.Clinic
{
    public class Clinic : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public Status ClinicStatus { get; set; } = Status.Active;
        public string? FacilityVideoUrl { get; set; }

        [ForeignKey("Doctor")]
        public Guid DoctorId { get; set; }

        [ForeignKey("Address")]
        public Guid AddressId { get; set; }

        // Navigation Properties
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Address Address { get; set; } = null!;
        public virtual ICollection<ClinicPhoto> Photos { get; set; } = new HashSet<ClinicPhoto>();
        public virtual ICollection<ClinicPhoneNumber> PhoneNumbers { get; set; } = new HashSet<ClinicPhoneNumber>();
        public virtual ICollection<ClinicService> OfferedServices { get; set; } = new HashSet<ClinicService>();
    }
}
