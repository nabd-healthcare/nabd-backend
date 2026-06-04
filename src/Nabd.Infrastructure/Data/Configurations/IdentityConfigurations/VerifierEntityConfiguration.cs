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
    public class VerifierEntityConfiguration : IEntityTypeConfiguration<Verifier>
    {
        public void Configure(EntityTypeBuilder<Verifier> builder)
        {
            // Table Mapping
            builder.ToTable("Verifiers");

            //// Properties
            //builder.Property(v => v.CreatedByAdminId).IsRequired();

            //// Indexes
            //builder.HasIndex(v => v.CreatedByAdminId)
            //    .HasDatabaseName("IX_Verifier_CreatedByAdminId");

            // Relationships - Verified Doctors
            builder.HasMany(v => v.VerifiedDoctors)
                .WithOne(d => d.Verifier)
                .HasForeignKey(d => d.VerifierId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
