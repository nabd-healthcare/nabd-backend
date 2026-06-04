using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nabd.Core.Entities.Shared;
using Nabd.Infrastructure.Data.Configurations.BaseConfigurations;

namespace Nabd.Infrastructure.Data.Configurations
{
	public class MedicalHistoryItemEntityConfiguration : AuditableEntityConfiguration<MedicalHistoryItem>
	{
		public override void Configure(EntityTypeBuilder<MedicalHistoryItem> builder)
		{
			base.Configure(builder);

			// Table Mapping
			builder.ToTable("MedicalHistoryItems");

			// Properties
			builder.Property(mhi => mhi.PatientId).IsRequired();
			builder.Property(mhi => mhi.Type).IsRequired().HasConversion<int>();
			builder.Property(mhi => mhi.Text).IsRequired().HasMaxLength(1000);

			// Indexes
			builder.HasIndex(mhi => mhi.PatientId)
				.HasDatabaseName("IX_MedicalHistoryItem_PatientId");

			builder.HasIndex(mhi => mhi.Type)
				.HasDatabaseName("IX_MedicalHistoryItem_Type");

			builder.HasIndex(mhi => new { mhi.PatientId, mhi.Type })
				.HasDatabaseName("IX_MedicalHistoryItem_Patient_Type");

			// Relationships
			builder.HasOne(mhi => mhi.Patient)
				.WithMany(p => p.MedicalHistory)
				.HasForeignKey(mhi => mhi.PatientId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
