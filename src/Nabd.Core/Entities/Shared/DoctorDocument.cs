using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nabd.Core.Entities.Identity;
using System.Xml.Linq;
using Nabd.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Nabd.Core.Enums.Doctor;
using Nabd.Core.Entities.Base;

namespace Nabd.Core.Entities.Common
{
    public class DoctorDocument : AuditableEntity
	{
		public string DocumentUrl { get; set; } = string.Empty;
        public DoctorDocumentType Type { get; set; }
        public VerificationDocumentStatus Status { get; set; } = VerificationDocumentStatus.UnderReview;
        public string? RejectionReason { get; set; }

        [ForeignKey("Doctor")]
        public Guid DoctorId { get; set; }


        // Navigation Properties
        public virtual Doctor Doctor { get; set; } = null!;
    }
}
