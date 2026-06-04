using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nabd.Core.Entities.Common;
using Nabd.Core.Entities.External.Clinic;
using Nabd.Core.Entities.External.Payments;
using Nabd.Core.Entities.Identity;
using Nabd.Core.Entities.Medical.Consultations;
using Nabd.Core.Entities.Medical.Schedules;
using Nabd.Core.Entities.Shared;
using Nabd.Core.Entities.System.Review;
using Nabd.Core.Entities.System;
using Nabd.Core.Entities.Base;
using System.Linq.Expressions;
using Nabd.Core.Entities.Medical;

namespace Nabd.Infrastructure.Data
{
	public class NabdDbContext : IdentityDbContext<User, Role, Guid>
	{

		public NabdDbContext(DbContextOptions<NabdDbContext> options)
		: base(options)
		{
		}

		#region DbSets
		/// <summary>
		/// External Entities
		/// </summary>
		// Clinics
		public DbSet<Clinic> Clinics { get; set; }
		public DbSet<ClinicPhoneNumber> ClinicPhoneNumbers { get; set; }
		public DbSet<ClinicPhoto> ClinicPhotos { get; set; }
		public DbSet<ClinicService> ClinicServices { get; set; }

		/// <summary>
		/// Identity Entities
		/// </summary>
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Patient> Patients { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Verifier> Verifiers { get; set; }
		public DbSet<RefreshToken> RefreshTokens { get; set; }

		/// <summary>
		/// Medical Entities
		/// </summary>
		// Appointments
		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<ConsultationRecord> ConsultationRecords { get; set; }
		// Consultations
		public DbSet<ConsultationType> ConsultationTypes { get; set; }
		public DbSet<DoctorConsultation> DoctorConsultations { get; set; }
		// Schedules
		public DbSet<DoctorAvailability> DoctorAvailability { get; set; }
		public DbSet<DoctorOverride> DoctorOverride { get; set; }
		// Prescriptions & Medications
		public DbSet<Prescription> Prescriptions { get; set; }
		public DbSet<Medication> Medications { get; set; }
		public DbSet<PrescribedMedication> PrescribedMedications { get; set; }
		public DbSet<DispensingRecord> DispensingRecords { get; set; }

		/// <summary>
		/// Shared Entities
		/// </summary>
		public DbSet<Address> Addresses { get; set; }
		public DbSet<DoctorDocument> DoctorDocument { get; set; }
		public DbSet<MedicalHistoryItem> MedicalHistoryItems { get; set; }

		/// <summary>
		/// System Entities
		/// </summary>
		// Review
		public DbSet<DoctorReview> DoctorReviews { get; set; }
		// Notification
		public DbSet<Notification> Notifications { get; set; }
		// Email Verification
		public DbSet<EmailVerification> EmailVerifications { get; set; }
		// Payment
		public DbSet<Payment> Payments { get; set; }
		public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
		#endregion

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfigurationsFromAssembly(typeof(NabdDbContext).Assembly);
		}

	}
}
