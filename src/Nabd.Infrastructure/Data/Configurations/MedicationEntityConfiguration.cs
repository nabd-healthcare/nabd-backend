using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nabd.Core.Entities.Medical;

namespace Nabd.Infrastructure.Data.Configurations
{
    public class MedicationEntityConfiguration : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.ToTable("Medications");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.BrandName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(m => m.GenericName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(m => m.Strength)
                .HasMaxLength(100);

            builder.Property(m => m.DosageForm)
                .HasMaxLength(100);

            builder.Property(m => m.Manufacturer)
                .HasMaxLength(100);

            builder.Property(m => m.Description)
                .HasMaxLength(1000);

            builder.HasIndex(m => new { m.BrandName, m.GenericName });

            builder.HasMany(m => m.PrescribedMedications)
                .WithOne(pm => pm.Medication)
                .HasForeignKey(pm => pm.MedicationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
