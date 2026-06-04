using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nabd.Core.Entities.Identity;
using Nabd.Infrastructure.Data;

namespace Nabd.Infrastructure.Seeders
{
    public static class DatabaseSeeder
    {
        public static async Task SeedDatabaseAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<NabdDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            // Ensure database is created
            await context.Database.MigrateAsync();

            // Seed in correct order (respecting foreign key dependencies)
            Console.WriteLine("Starting database seeding...");

            // 1. Seed Base Data (No FK dependencies)
            await ConsultationTypeSeed.SeedAsync(context);
            await MedicationSeed.SeedAsync(context);

            // 2. Seed Users (Identity) - with UserManager for password hashing
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
            await RoleSeed.SeedAsync(roleManager);

            await VerifierSeed.SeedAsync(context, userManager);
            await PatientSeed.SeedAsync(context, userManager);
            await DoctorSeed.SeedAsync(context, userManager);

            // 3. Seed Related Entities
            await DoctorAvailabilitySeed.SeedAsync(context);
            await DoctorConsultationSeed.SeedAsync(context);
            await ClinicSeed.SeedAsync(context);

            // 4. Seed Transactional Data
            await AppointmentSeed.SeedAsync(context);
            await PrescriptionSeed.SeedAsync(context);

            // 5. Seed Reviews (depends on completed appointments)
            await ReviewSeed.SeedAsync(context);

            Console.WriteLine("Database seeding completed successfully!");
        }

        public static async Task ClearDatabaseAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<NabdDbContext>();

            Console.WriteLine("🗑️ Clearing database...");

            // Clear in reverse order of seeding (respecting FK dependencies)
            
            // 1. Reviews
            context.DoctorReviews.RemoveRange(context.DoctorReviews);

            // 2. Transactional Data - child tables first
            context.PrescribedMedications.RemoveRange(context.PrescribedMedications);
            context.Prescriptions.RemoveRange(context.Prescriptions);
            context.ConsultationRecords.RemoveRange(context.ConsultationRecords);
            context.Appointments.RemoveRange(context.Appointments);

            // 3. Related Entities - child tables first
            context.ClinicServices.RemoveRange(context.ClinicServices);
            context.ClinicPhoneNumbers.RemoveRange(context.ClinicPhoneNumbers);
            context.ClinicPhotos.RemoveRange(context.ClinicPhotos);
            context.Clinics.RemoveRange(context.Clinics);
            context.DoctorConsultations.RemoveRange(context.DoctorConsultations);
            context.DoctorAvailability.RemoveRange(context.DoctorAvailability);
            context.DoctorOverride.RemoveRange(context.DoctorOverride);
            
            // 4. Documents
            context.DoctorDocument.RemoveRange(context.DoctorDocument);
            
            // 5. Medical History
            context.MedicalHistoryItems.RemoveRange(context.MedicalHistoryItems);

            // 6. Users/Identity
            context.Doctors.RemoveRange(context.Doctors);
            context.Patients.RemoveRange(context.Patients);
            context.Verifiers.RemoveRange(context.Verifiers);

            // 7. Addresses
            context.Addresses.RemoveRange(context.Addresses);

            // 8. Base/Master Data
            context.Medications.RemoveRange(context.Medications);
            context.ConsultationTypes.RemoveRange(context.ConsultationTypes);

            await context.SaveChangesAsync();
            Console.WriteLine("Database cleared successfully!");
        }
    }
}