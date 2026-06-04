using Microsoft.EntityFrameworkCore;
using Nabd.Core.Entities.Medical;
using Nabd.Core.Interfaces.Repositories;
using Nabd.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nabd.Infrastructure.Repositories
{
    public class DispensingRecordRepository : GenericRepository<DispensingRecord>, IDispensingRecordRepository
    {
        public DispensingRecordRepository(NabdDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DispensingRecord>> GetByPrescriptionIdAsync(Guid prescriptionId)
        {
            return await _context.DispensingRecords
                .Include(d => d.PrescribedMedication)
                .ThenInclude(pm => pm.Medication)
                .Where(d => d.PrescribedMedication.MedicationPrescriptionId == prescriptionId)
                .OrderByDescending(d => d.DispensedDate)
                .ToListAsync();
        }
    }
}
