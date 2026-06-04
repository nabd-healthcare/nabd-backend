using Nabd.Core.Entities.Medical;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nabd.Core.Interfaces.Repositories.MedicationRepositories
{
    public interface IPrescriptionRepository : IGenericRepository<Prescription>
    {
        Task<Prescription?> GetByPrescriptionNumberAsync(string prescriptionNumber);
        Task<IEnumerable<Prescription>> GetByDoctorIdAsync(Guid doctorId);
        Task<IEnumerable<Prescription>> GetByPatientIdAsync(Guid patientId);
        Task<IEnumerable<Prescription>> GetByAppointmentIdAsync(Guid appointmentId);
        
        // Extended methods necessary for service layer
        Task<Prescription?> GetPrescriptionWithDetailsAsync(Guid id);
        Task<(IEnumerable<Prescription> Items, int TotalCount)> GetPagedPrescriptionsForPatientAsync(Guid patientId, int pageNumber, int pageSize);
        Task<IEnumerable<Prescription>> GetActivePrescriptionsForPatientAsync(Guid patientId);
        Task<IEnumerable<Prescription>> GetPrescriptionsContainingMedicationAsync(string medicationName);
        Task<IEnumerable<Prescription>> GetPrescriptionsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Prescription>> GetAllPrescriptionsForPatientWithDetailsAsync(Guid patientId);
    }
}
