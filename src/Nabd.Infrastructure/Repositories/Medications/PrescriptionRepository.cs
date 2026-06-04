using Microsoft.EntityFrameworkCore;
using Nabd.Core.Entities.Medical;
using Nabd.Core.Interfaces.Repositories.MedicationRepositories;
using Nabd.Infrastructure.Data;
using Nabd.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nabd.Infrastructure.Repositories.Medications
{
    public class PrescriptionRepository : GenericRepository<Prescription>, IPrescriptionRepository
    {
        public PrescriptionRepository(NabdDbContext context) : base(context)
        {
        }

        public async Task<Prescription?> GetByPrescriptionNumberAsync(string prescriptionNumber)
        {
            return await _context.Prescriptions
                .Include(p => p.Doctor)
                .Include(p => p.Patient)
                .Include(p => p.PrescribedMedications)
                    .ThenInclude(pm => pm.Medication)
                .FirstOrDefaultAsync(p => p.PrescriptionNumber == prescriptionNumber);
        }

        public async Task<IEnumerable<Prescription>> GetByDoctorIdAsync(Guid doctorId)
        {
            return await _context.Prescriptions
                .Where(p => p.DoctorId == doctorId)
                .Include(p => p.Patient)
                .Include(p => p.PrescribedMedications)
                    .ThenInclude(pm => pm.Medication)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Prescription>> GetByPatientIdAsync(Guid patientId)
        {
            return await _context.Prescriptions
                .Where(p => p.PatientId == patientId)
                .Include(p => p.Doctor)
                .Include(p => p.PrescribedMedications)
                    .ThenInclude(pm => pm.Medication)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Prescription>> GetByAppointmentIdAsync(Guid appointmentId)
        {
            return await _context.Prescriptions
                .Where(p => p.AppointmentId == appointmentId)
                .Include(p => p.Doctor)
                .Include(p => p.Patient)
                .Include(p => p.PrescribedMedications)
                    .ThenInclude(pm => pm.Medication)
                .ToListAsync();
        }

        public async Task<Prescription?> GetPrescriptionWithDetailsAsync(Guid id)
        {
            return await _context.Prescriptions
                .Include(p => p.Doctor)
                .Include(p => p.Patient)
                .Include(p => p.PrescribedMedications)
                    .ThenInclude(pm => pm.Medication)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<(IEnumerable<Prescription> Items, int TotalCount)> GetPagedPrescriptionsForPatientAsync(Guid patientId, int pageNumber, int pageSize)
        {
            var query = _context.Prescriptions
                .Where(p => p.PatientId == patientId);

            var totalCount = await query.CountAsync();
            var items = await query
                .Include(p => p.Doctor)
                .Include(p => p.PrescribedMedications)
                    .ThenInclude(pm => pm.Medication)
                .OrderByDescending(p => p.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<IEnumerable<Prescription>> GetActivePrescriptionsForPatientAsync(Guid patientId)
        {
            return await _context.Prescriptions
                .Where(p => p.PatientId == patientId && p.Status == Core.Enums.PrescriptionStatus.Active)
                .Include(p => p.Doctor)
                .Include(p => p.PrescribedMedications)
                    .ThenInclude(pm => pm.Medication)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsContainingMedicationAsync(string medicationName)
        {
            return await _context.Prescriptions
                .Where(p => p.PrescribedMedications.Any(pm => pm.Medication.BrandName.Contains(medicationName) || pm.Medication.GenericName.Contains(medicationName)))
                .Include(p => p.Doctor)
                .Include(p => p.Patient)
                .Include(p => p.PrescribedMedications)
                    .ThenInclude(pm => pm.Medication)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Prescriptions
                .Where(p => p.CreatedAt >= startDate && p.CreatedAt <= endDate)
                .Include(p => p.Doctor)
                .Include(p => p.Patient)
                .Include(p => p.PrescribedMedications)
                    .ThenInclude(pm => pm.Medication)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Prescription>> GetAllPrescriptionsForPatientWithDetailsAsync(Guid patientId)
        {
            return await _context.Prescriptions
                .Where(p => p.PatientId == patientId)
                .Include(p => p.Doctor)
                .Include(p => p.PrescribedMedications)
                    .ThenInclude(pm => pm.Medication)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }
    }
}
