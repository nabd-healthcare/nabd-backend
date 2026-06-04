using System;
using System.ComponentModel.DataAnnotations.Schema;
using Nabd.Core.Entities.Base;
using Nabd.Core.Entities.Identity;
using Nabd.Core.Enums;

namespace Nabd.Core.Entities.Shared
{
	public class MedicalHistoryItem : AuditableEntity
	{
		[ForeignKey("Patient")]
		public Guid PatientId { get; set; }

		public MedicalHistoryType Type { get; set; }
		public string Text { get; set; } = string.Empty;

		// Navigation Properties
		public virtual Patient Patient { get; set; } = null!;
	}
}
