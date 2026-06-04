using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nabd.Core.Entities.Medical;

namespace Nabd.Infrastructure.Data.Configurations
{
    public class PrescriptionEntityConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescriptions");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.PrescriptionNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(p => p.PrescriptionNumber)
                .IsUnique();

            builder.Property(p => p.DigitalSignature)
                .HasMaxLength(500);

            builder.Property(p => p.GeneralInstructions)
                .HasMaxLength(1000);

            builder.Property(p => p.CancellationReason)
                .HasMaxLength(500);

            // Relationships
            builder.HasOne(p => p.Doctor)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Appointment)
                .WithOne(a => a.Prescription)
                .HasForeignKey<Prescription>(p => p.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PrescribedMedications)
                .WithOne(pm => pm.Prescription)
                .HasForeignKey(pm => pm.MedicationPrescriptionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
