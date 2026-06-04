using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nabd.Core.Entities.Identity;
using Nabd.Core.Enums;
using Nabd.Core.Enums.Identity;
using Nabd.Infrastructure.Data;

namespace Nabd.Infrastructure.Seeders
{
    public static class QuickTestUserSeed
    {
        private const string DefaultPassword = "Test@123";

        public static async Task SeedTestUsersAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<NabdDbContext>();
            var patientUserManager = scope.ServiceProvider.GetRequiredService<UserManager<Patient>>();
            var doctorUserManager = scope.ServiceProvider.GetRequiredService<UserManager<Doctor>>();

            // Ensure database is created
            await context.Database.MigrateAsync();

            Console.WriteLine("Creating test users...");

            // Create a test patient
            if (!await context.Patients.AnyAsync(p => p.Email == "test.patient@gmail.com"))
            {
                var testPatient = new Patient
                {
                    FirstName = "Test",
                    LastName = "Patient",
                    Email = "test.patient@gmail.com",
                    UserName = "test.patient@gmail.com",
                    PhoneNumber = "+201234567890",
                    BirthDate = new DateTime(1990, 1, 1),
                    Gender = Gender.Male,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedAt = DateTime.UtcNow
                };

                var result = await patientUserManager.CreateAsync(testPatient, DefaultPassword);
                if (result.Succeeded)
                {
                    Console.WriteLine($"✅ Test patient created: {testPatient.Email}, Password: {DefaultPassword}");
                }
                else
                {
                    Console.WriteLine($"❌ Failed to create test patient: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }

            // Create a test doctor
            if (!await context.Doctors.AnyAsync(d => d.Email == "test.doctor@gmail.com"))
            {
                var testDoctor = new Doctor
                {
                    FirstName = "Test",
                    LastName = "Doctor",
                    Email = "test.doctor@gmail.com",
                    UserName = "test.doctor@gmail.com",
                    PhoneNumber = "+201234567891",
                    BirthDate = new DateTime(1980, 1, 1),
                    Gender = Gender.Male,
                    MedicalSpecialty = Nabd.Core.Enums.Doctor.MedicalSpecialty.GeneralMedicine,
                    YearsOfExperience = 10,
                    Biography = "Test doctor for development",
                    VerificationStatus = VerificationStatus.Verified,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedAt = DateTime.UtcNow
                };

                var result = await doctorUserManager.CreateAsync(testDoctor, DefaultPassword);
                if (result.Succeeded)
                {
                    Console.WriteLine($"✅ Test doctor created: {testDoctor.Email}, Password: {DefaultPassword}");
                }
                else
                {
                    Console.WriteLine($"❌ Failed to create test doctor: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }

            Console.WriteLine("Test users creation completed!");
        }
    }
}
