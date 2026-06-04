using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Nabd.Core.Interfaces.Repositories;
using Nabd.Core.Interfaces.Repositories.ClinicRepositories;
using Nabd.Core.Interfaces.Repositories.ReviewRepositories;
using Nabd.Core.Interfaces.Repositories.MedicationRepositories;
using Nabd.Infrastructure.Data;
using Nabd.Infrastructure.Repositories.Doctors;
using Nabd.Infrastructure.Repositories.Patients;
using Nabd.Infrastructure.Repositories.Medical;
using Nabd.Infrastructure.Repositories.Clinics;
using Nabd.Infrastructure.Repositories.Reviews;
using Nabd.Infrastructure.Repositories.Medications;
using Nabd.Infrastructure.Repositories.Shared;
using Nabd.Core.Interfaces.UnitOfWork;
using Nabd.Infrastructure.Repositories;

namespace Nabd.Infrastructure.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
    {
        private readonly NabdDbContext _context;
        private IDbContextTransaction? _transaction;

        // ==================== Doctor Related Fields ====================
        private IDoctorRepository? _doctors;
        private IDoctorAvailabilityRepository? _doctorAvailabilities;
        private IDoctorConsultationRepository? _doctorConsultations;
        private IDoctorOverrideRepository? _doctorOverrides;
        private IDoctorDocumentRepository? _doctorDocuments;


        // ==================== Patient Related Fields ====================
        private IPatientRepository? _patients;
        private IMedicalHistoryItemRepository? _medicalHistoryItems;

        // ==================== Medical/Appointment Related Fields ====================
        private IAppointmentRepository? _appointments;
        private IConsultationRecordRepository? _consultationRecords;
        private IConsultationTypeRepository? _consultationTypes;

        // ==================== Clinic Related Fields ====================
        private IClinicRepository? _clinics;
        private IClinicPhoneNumberRepository? _clinicPhoneNumbers;
        private IClinicPhotosRepository? _clinicPhotos;
        private IClinicServiceRepository? _clinicServices;

        // ==================== Prescription Related Fields ====================
        private IPrescriptionRepository? _prescriptions;
        private IMedicationRepository? _medications;
        private IPrescribedMedicationRepository? _prescribedMedications;
        private IDispensingRecordRepository? _dispensingRecords;

        // ==================== Review Related Fields ====================
        private IDoctorReviewRepository? _doctorReviews;

        // ==================== Shared Fields ====================
        private IVerifierRepository? _verifiers;
        private INotificationRepository? _notifications;
        private IRefreshTokenRepository? _refreshTokens;

        // ==================== Payment Related Fields ====================
        private IPaymentRepository? _payments;


        public UnitOfWork(NabdDbContext context)
        {
            _context = context;
        }

        // ==================== Doctor Related Properties ====================
        public IDoctorRepository Doctors =>
            _doctors ??= new DoctorRepository(_context);

        public IDoctorAvailabilityRepository DoctorAvailabilities =>
            _doctorAvailabilities ??= new DoctorAvailabilityRepository(_context);

        public IDoctorConsultationRepository DoctorConsultations =>
            _doctorConsultations ??= new DoctorConsultationRepository(_context);

        public IDoctorOverrideRepository DoctorOverrides =>
            _doctorOverrides ??= new DoctorOverrideRepository(_context);

        public IDoctorDocumentRepository DoctorDocuments =>
            _doctorDocuments ??= new DoctorDocumentRepository(_context);



        // ==================== Patient Related Properties ====================
        public IPatientRepository Patients =>
            _patients ??= new PatientRepository(_context);

        public IMedicalHistoryItemRepository MedicalHistoryItems =>
            _medicalHistoryItems ??= new MedicalHistoryItemRepository(_context);

        // ==================== Medical/Appointment Related Properties ====================
        public IAppointmentRepository Appointments =>
            _appointments ??= new AppointmentRepository(_context);

        public IConsultationRecordRepository ConsultationRecords =>
            _consultationRecords ??= new ConsultationRecordRepository(_context);

        public IConsultationTypeRepository ConsultationTypes =>
            _consultationTypes ??= new ConsultationTypeRepository(_context);

        // ==================== Clinic Related Properties ====================
        public IClinicRepository Clinics =>
            _clinics ??= new ClinicRepository(_context);

        public IClinicPhoneNumberRepository ClinicPhoneNumbers =>
            _clinicPhoneNumbers ??= new ClinicPhoneNumberRepository(_context);

        public IClinicPhotosRepository ClinicPhotos =>
            _clinicPhotos ??= new ClinicPhotosRepository(_context);

        public IClinicServiceRepository ClinicServices =>
            _clinicServices ??= new ClinicServiceRepository(_context);

        // ==================== Prescription Related Properties ====================
        public IPrescriptionRepository Prescriptions =>
            _prescriptions ??= new PrescriptionRepository(_context);

        public IMedicationRepository Medications =>
            _medications ??= new MedicationRepository(_context);

        public IPrescribedMedicationRepository PrescribedMedications =>
            _prescribedMedications ??= new PrescribedMedicationRepository(_context);

        public IDispensingRecordRepository DispensingRecords =>
            _dispensingRecords ??= new DispensingRecordRepository(_context);

        // ==================== Review Related Properties ====================
        public IDoctorReviewRepository DoctorReviews =>
            _doctorReviews ??= new DoctorReviewRepository(_context);

        // ==================== Shared Properties ====================
        public IVerifierRepository Verifiers =>
            _verifiers ??= new VerifierRepository(_context);

        public INotificationRepository Notifications =>
            _notifications ??= new NotificationRepository(_context);

        public IRefreshTokenRepository RefreshTokens =>
            _refreshTokens ??= new RefreshTokenRepository(_context);

        // ==================== Payment Related Properties ====================
        public IPaymentRepository Payments =>
            _payments ??= new Nabd.Infrastructure.Repositories.Payments.PaymentRepository(_context);

        // ==================== Generic Repository ====================
        public IGenericRepository<T> Repository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        // ==================== Transaction Methods ====================
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            return _transaction;
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                if (_transaction != null)
                {
                await _transaction.CommitAsync(cancellationToken);
                }
            }
            catch
            {
                await RollbackTransactionAsync(cancellationToken);
                throw;
            }
            finally
            {
                if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction != null)
            {
            await _transaction.RollbackAsync(cancellationToken);
            await _transaction.DisposeAsync();
            _transaction = null;
            }
        }

       // ==================== Dispose Pattern ====================

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}