using Microsoft.EntityFrameworkCore;
using Nabd.Core.Entities.Common;
using Nabd.Core.Entities.Shared;
using Nabd.Core.Enums;
using Nabd.Core.Interfaces.Repositories;
using Nabd.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nabd.Infrastructure.Repositories.Medical
{
    public class MedicalHistoryItemRepository : GenericRepository<MedicalHistoryItem>, IMedicalHistoryItemRepository
    {
        public MedicalHistoryItemRepository(NabdDbContext context) : base(context) { }

        public async Task<IEnumerable<MedicalHistoryItem>> GetByPatientIdAsync(Guid patientId)
        {
            return await _dbSet
                .Include(mhi => mhi.Patient)
                .Where(mhi => mhi.PatientId == patientId)
                .OrderByDescending(mhi => mhi.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<MedicalHistoryItem>> GetByTypeAsync(Guid patientId, MedicalHistoryType type)
        {
            return await _dbSet
                .Where(mhi => mhi.PatientId == patientId && mhi.Type == type)
                .OrderByDescending(mhi => mhi.CreatedAt)
                .ToListAsync();
        }
    }
}

