using Microsoft.EntityFrameworkCore;
using Nabd.Core.Entities.Identity;
using Nabd.Core.Enums.Identity;
using Nabd.Core.Interfaces.Repositories;
using Nabd.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nabd.Infrastructure.Repositories.Shared
{
    public class VerifierRepository : GenericRepository<Verifier>, IVerifierRepository
    {
        public VerifierRepository(NabdDbContext context) : base(context) { }

        public async Task<Verifier?> GetByIdWithVerifiedEntitiesAsync(Guid id)
        {
            return await _dbSet
                .Include(v => v.VerifiedDoctors)
                    .ThenInclude(d => d.Clinic)

                .FirstOrDefaultAsync(v => v.Id == id && !v.IsDeleted);
        }

        public async Task<Verifier?> GetByEmailAsync(string email)
        {
            return await _dbSet
                .FirstOrDefaultAsync(v => v.Email == email && !v.IsDeleted);
        }

        public async Task<int> GetVerifiedDoctorsCountAsync(Guid verifierId)
        {
            return await _dbSet
                .Where(v => v.Id == verifierId && !v.IsDeleted)
                .SelectMany(v => v.VerifiedDoctors)
                .CountAsync();
        }
    }
}

