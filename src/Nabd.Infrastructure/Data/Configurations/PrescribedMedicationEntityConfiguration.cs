using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nabd.Core.Entities.Medical;

namespace Nabd.Infrastructure.Data.Configurations
{
    public class PrescribedMedicationEntityConfiguration : IEntityTypeConfiguration<PrescribedMedication>
    {
        public void Configure(EntityTypeBuilder<PrescribedMedication> builder)
        {
            builder.ToTable("PrescribedMedications");

            builder.HasKey(pm => pm.Id);

            builder.Property(pm => pm.Dosage)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(pm => pm.Frequency)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(pm => pm.SpecialInstructions)
                .HasMaxLength(500);

            builder.HasOne(pm => pm.Prescription)
                .WithMany(p => p.PrescribedMedications)
                .HasForeignKey(pm => pm.MedicationPrescriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pm => pm.Medication)
                .WithMany(m => m.PrescribedMedications)
                .HasForeignKey(pm => pm.MedicationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(pm => pm.DispensingRecords)
                .WithOne(dr => dr.PrescribedMedication)
                .HasForeignKey(dr => dr.PrescribedMedicationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
