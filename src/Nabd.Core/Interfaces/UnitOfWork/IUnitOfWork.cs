using Microsoft.EntityFrameworkCore.Storage;
using Nabd.Core.Interfaces.Repositories;
using Nabd.Core.Interfaces.Repositories.ClinicRepositories;
using Nabd.Core.Interfaces.Repositories.MedicationRepositories;
using Nabd.Core.Interfaces.Repositories.ReviewRepositories;

namespace Nabd.Core.Interfaces.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
    {
        // ==================== Doctor Related Repositories ====================
        IDoctorRepository Doctors { get; }
        IDoctorAvailabilityRepository DoctorAvailabilities { get; }
        IDoctorConsultationRepository DoctorConsultations { get; }
        IDoctorOverrideRepository DoctorOverrides { get; }
        IDoctorDocumentRepository DoctorDocuments { get; }


        // ==================== Patient Related Repositories ====================
        IPatientRepository Patients { get; }
        IMedicalHistoryItemRepository MedicalHistoryItems { get; }

        // ==================== Medical/Appointment Related Repositories ====================
        IAppointmentRepository Appointments { get; }
        IConsultationRecordRepository ConsultationRecords { get; }
        IConsultationTypeRepository ConsultationTypes { get; }

        // ==================== Clinic Related Repositories ====================
        IClinicRepository Clinics { get; }
        IClinicPhoneNumberRepository ClinicPhoneNumbers { get; }
        IClinicPhotosRepository ClinicPhotos { get; }
        IClinicServiceRepository ClinicServices { get; }


        // ==================== Prescription Related Repositories ====================
        IPrescriptionRepository Prescriptions { get; }
        IMedicationRepository Medications { get; }
        IPrescribedMedicationRepository PrescribedMedications { get; }
        IDispensingRecordRepository DispensingRecords { get; }

        // ==================== Review Related Repositories ====================
        IDoctorReviewRepository DoctorReviews { get; }

        // ==================== Shared Repositories ====================
        IVerifierRepository Verifiers { get; }
        INotificationRepository Notifications { get; }
        IRefreshTokenRepository RefreshTokens { get; }

        // ==================== Payment Related Repositories ====================
        IPaymentRepository Payments { get; }


        // ==================== Generic Repository ====================
        IGenericRepository<T> Repository<T>() where T : class;

        // ==================== Transaction Methods ====================
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}