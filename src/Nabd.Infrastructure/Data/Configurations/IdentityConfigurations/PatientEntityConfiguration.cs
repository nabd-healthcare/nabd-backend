using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nabd.Core.Entities.Identity;

namespace Nabd.Infrastructure.Data.Configurations.IdentityConfigurations
{
    public class PatientEntityConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            // Table Mapping
            builder.ToTable("Patients");

            // Properties
            builder.Property(p => p.AddressId).IsRequired(false);

            // Indexes
            builder.HasIndex(p => p.AddressId)
                .HasDatabaseName("IX_Patient_AddressId");

            // Address Relationship (One-to-One, Optional)
            builder.HasOne(p => p.Address)
                .WithOne()
                .HasForeignKey<Patient>(p => p.AddressId)
                .OnDelete(DeleteBehavior.SetNull);

            // Medical History Relationship (One-to-Many)
            builder.HasMany(p => p.MedicalHistory)
                .WithOne(mhi => mhi.Patient)
                .HasForeignKey(mhi => mhi.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Appointments Relationship (One-to-Many)
            builder.HasMany(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Lab Orders Relationship (One-to-Many)


            // Prescriptions Relationship (One-to-Many)
            builder.HasMany(p => p.Prescriptions)
                .WithOne(pr => pr.Patient)
                .HasForeignKey(pr => pr.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Pharmacy Orders Relationship (One-to-Many)


            // Doctor Reviews Relationship (One-to-Many)
            builder.HasMany(p => p.DoctorReviews)
                .WithOne(dr => dr.Patient)
                .HasForeignKey(dr => dr.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Laboratory Reviews Relationship (One-to-Many)

        }
    }
}
