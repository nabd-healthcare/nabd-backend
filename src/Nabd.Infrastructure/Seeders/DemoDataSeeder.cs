using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nabd.Core.Entities.Identity;
using Nabd.Core.Entities.Medical;
using Nabd.Core.Entities.Medical.Consultations;
using Nabd.Core.Enums;
using Nabd.Core.Enums.Appointments;
using Nabd.Core.Enums.Identity;
using Nabd.Infrastructure.Data;

namespace Nabd.Infrastructure.Seeders
{
    public static class DemoDataSeeder
    {
        public static async Task SeedGuaranteedDemoDataAsync(NabdDbContext context, UserManager<User> userManager)
        {
            var doctorEmail = "demo.doctor@nabdhealth.me";
            var patientEmail = "demo.patient@nabdhealth.me";
            var defaultPassword = "Test@123";

            // 1. Ensure Doctor Exists
            var doctor = await context.Doctors.Include(d => d.Consultations).FirstOrDefaultAsync(d => d.Email == doctorEmail);
            if (doctor == null)
            {
                var defaultConsultationType = await context.ConsultationTypes.FirstOrDefaultAsync();

                doctor = new Doctor
                {
                    FirstName = "د. أحمد",
                    LastName = "التجريبي",
                    Email = doctorEmail,
                    UserName = doctorEmail,
                    PhoneNumber = "+201111111112",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-60),
                    BirthDate = new DateTime(1980, 1, 1),
                    Gender = Gender.Male,
                    VerificationStatus = VerificationStatus.Verified,
                    MedicalSpecialty = Nabd.Core.Enums.Doctor.MedicalSpecialty.GeneralMedicine,
                    YearsOfExperience = 10,
                    Biography = "طبيب تجريبي لاختبار النظام",
                    Consultations = defaultConsultationType != null ? new List<DoctorConsultation>
                    {
                        new DoctorConsultation
                        {
                            ConsultationTypeId = defaultConsultationType.Id,
                            ConsultationFee = 500,
                            SessionDurationMinutes = 30
                        }
                    } : new List<DoctorConsultation>()
                };
                var result = await userManager.CreateAsync(doctor, defaultPassword);
                if (!result.Succeeded)
                {
                    Console.WriteLine($"Failed to create demo doctor: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    return;
                }
            }

            // 2. Ensure Patient Exists
            var patient = await context.Patients.FirstOrDefaultAsync(p => p.Email == patientEmail);
            if (patient == null)
            {
                patient = new Patient
                {
                    FirstName = "مريض",
                    LastName = "تجريبي",
                    Email = patientEmail,
                    UserName = patientEmail,
                    PhoneNumber = "+201111111113",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-60),
                    BirthDate = new DateTime(1990, 1, 1),
                    Gender = Gender.Male
                };
                var result = await userManager.CreateAsync(patient, defaultPassword);
                if (!result.Succeeded)
                {
                    Console.WriteLine($"Failed to create demo patient: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    return;
                }
            }

            var consultation = doctor.Consultations?.FirstOrDefault() ?? new DoctorConsultation 
            { 
                DoctorId = doctor.Id, 
                ConsultationFee = 500, 
                SessionDurationMinutes = 30 
            };

            var hasPastAppointment = await context.Appointments
                .AnyAsync(a => a.DoctorId == doctor.Id && a.PatientId == patient.Id && a.Status == AppointmentStatus.Completed);
            
            var hasTodayAppointment = await context.Appointments
                .AnyAsync(a => a.DoctorId == doctor.Id && a.PatientId == patient.Id && a.ScheduledStartTime.Date == DateTime.UtcNow.Date);

            Console.WriteLine("Seeding Guaranteed Demo Appointments for isolated demo accounts...");

            if (!hasPastAppointment)
            {
                var pastAppt = new Appointment
                {
                    Id = Guid.NewGuid(),
                    PatientId = patient.Id,
                    DoctorId = doctor.Id,
                    ScheduledStartTime = DateTime.UtcNow.AddDays(-5).AddHours(10),
                    ScheduledEndTime = DateTime.UtcNow.AddDays(-5).AddHours(10).AddMinutes(consultation.SessionDurationMinutes),
                    ConsultationType = ConsultationTypeEnum.Regular,
                    ConsultationFee = consultation.ConsultationFee,
                    SessionDurationMinutes = consultation.SessionDurationMinutes,
                    Status = AppointmentStatus.Completed,
                    CreatedAt = DateTime.UtcNow.AddDays(-7)
                };

                var pastRecord = new ConsultationRecord
                {
                    Id = Guid.NewGuid(),
                    AppointmentId = pastAppt.Id,
                    ChiefComplaint = "ألم حاد في المعدة",
                    HistoryOfPresentIllness = "بدأ منذ يومين بعد تناول وجبة دسمة",
                    PhysicalExamination = "نبض طبيعي، حرارة طبيعية، ألم عند الضغط",
                    Diagnosis = "التهاب بسيط في جدار المعدة",
                    ManagementPlan = "مسكنات ومضادات حموضة مع راحة",
                    CreatedAt = DateTime.UtcNow.AddDays(-5).AddHours(11)
                };

                await context.Appointments.AddAsync(pastAppt);
                await context.ConsultationRecords.AddAsync(pastRecord);
            }

            if (!hasTodayAppointment)
            {
                var todayAppt = new Appointment
                {
                    Id = Guid.NewGuid(),
                    PatientId = patient.Id,
                    DoctorId = doctor.Id,
                    ScheduledStartTime = DateTime.UtcNow.AddHours(2),
                    ScheduledEndTime = DateTime.UtcNow.AddHours(2).AddMinutes(consultation.SessionDurationMinutes),
                    ConsultationType = ConsultationTypeEnum.FollowUp,
                    ConsultationFee = 0,
                    SessionDurationMinutes = consultation.SessionDurationMinutes,
                    Status = AppointmentStatus.Confirmed,
                    CreatedAt = DateTime.UtcNow.AddDays(-1)
                };
                
                await context.Appointments.AddAsync(todayAppt);
            }

            await context.SaveChangesAsync();
            Console.WriteLine("Guaranteed Demo Data seeded successfully!");
        }
    }
}
