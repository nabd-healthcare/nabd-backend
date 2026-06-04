using Microsoft.EntityFrameworkCore;
using Nabd.Core.Entities.Medical;
using Nabd.Core.Interfaces.Repositories.MedicationRepositories;
using Nabd.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nabd.Infrastructure.Repositories.Medications
{
    public class PrescribedMedicationRepository : GenericRepository<PrescribedMedication>, IPrescribedMedicationRepository
    {
        public PrescribedMedicationRepository(NabdDbContext context) : base(context) { }

        public async Task<IEnumerable<PrescribedMedication>> GetByPrescriptionAsync(Guid prescriptionId)
        {
            return await _dbSet
                .Include(pm => pm.Medication)
                .Where(pm => pm.MedicationPrescriptionId == prescriptionId)
                .OrderBy(pm => pm.Medication.BrandName)
                .ToListAsync();
        }

        public async Task<PrescribedMedication?> GetPrescribedMedicationAsync(Guid prescriptionId, Guid medicationId)
        {
            return await _dbSet
                .Include(pm => pm.Medication)
                .FirstOrDefaultAsync(pm => pm.MedicationPrescriptionId == prescriptionId 
                    && pm.MedicationId == medicationId);
        }

        public async Task<IEnumerable<PrescribedMedication>> GetPrescriptionsContainingMedicationAsync(Guid medicationId)
        {
            return await _dbSet
                .Include(pm => pm.Prescription)
                    .ThenInclude(p => p.Doctor)
                .Include(pm => pm.Medication)
                .Where(pm => pm.MedicationId == medicationId)
                .OrderByDescending(pm => pm.Prescription.CreatedAt)
                .ToListAsync();
        }
    }
}

