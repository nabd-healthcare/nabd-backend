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
    public class MedicationRepository : GenericRepository<Medication>, IMedicationRepository
    {
        public MedicationRepository(NabdDbContext context) : base(context) { }



        public async Task<IEnumerable<Medication>> SearchMedicationsAsync(string searchTerm)
        {
            var lowerSearch = searchTerm.ToLower();
            return await _dbSet
                .Where(m => m.BrandName.ToLower().Contains(lowerSearch) 
                    || (m.GenericName != null && m.GenericName.ToLower().Contains(lowerSearch)))
                .OrderBy(m => m.BrandName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Medication>> GetByManufacturerAsync(string manufacturer)
        {
            return await _dbSet
                .Where(m => m.Manufacturer != null && m.Manufacturer.ToLower() == manufacturer.ToLower())
                .OrderBy(m => m.BrandName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Medication>> GetPrescriptionRequiredMedicationsAsync()
        {
            return await _dbSet
                .Where(m => m.RequiresPrescription)
                .OrderBy(m => m.BrandName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Medication>> GetMostPrescribedMedicationsAsync(int count)
        {
            return await _dbSet
                .Include(m => m.PrescribedMedications)
                .OrderByDescending(m => m.PrescribedMedications.Count)
                .Take(count)
                .ToListAsync();
        }
    }
}

