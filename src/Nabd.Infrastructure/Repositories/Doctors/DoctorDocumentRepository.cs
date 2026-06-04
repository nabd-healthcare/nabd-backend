using Microsoft.EntityFrameworkCore;
using Nabd.Core.Entities.Common;
using Nabd.Core.Enums;
using Nabd.Core.Interfaces.Repositories;
using Nabd.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nabd.Infrastructure.Repositories.Doctors
{
    public class DoctorDocumentRepository : GenericRepository<DoctorDocument>, IDoctorDocumentRepository
    {
        public DoctorDocumentRepository(NabdDbContext context) : base(context) { }

        public async Task<IEnumerable<DoctorDocument>> GetByDoctorIdAsync(Guid doctorId)
        {
            return await _dbSet
                .Include(dd => dd.Doctor)
                .Where(dd => dd.DoctorId == doctorId)
                .OrderByDescending(dd => dd.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<DoctorDocument>> GetPendingDocumentsAsync()
        {
            return await _dbSet
                .Include(dd => dd.Doctor)
                .Where(dd => dd.Status == VerificationDocumentStatus.UnderReview)
                .OrderBy(dd => dd.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<DoctorDocument>> GetByStatusAsync(VerificationDocumentStatus status)
        {
            return await _dbSet
                .Include(dd => dd.Doctor)
                .Where(dd => dd.Status == status)
                .OrderByDescending(dd => dd.CreatedAt)
                .ToListAsync();
        }
    }
}

