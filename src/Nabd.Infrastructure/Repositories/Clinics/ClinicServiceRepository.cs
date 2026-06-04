using Microsoft.EntityFrameworkCore;
using Nabd.Core.Entities.External.Clinic;
using Nabd.Core.Interfaces.Repositories.ClinicRepositories;
using Nabd.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nabd.Infrastructure.Repositories.Clinics
{
    public class ClinicServiceRepository : GenericRepository<ClinicService>, IClinicServiceRepository
    {
        public ClinicServiceRepository(NabdDbContext context) : base(context) { }

        public async Task<IEnumerable<ClinicService>> GetClinicServicesAsync(Guid clinicId)
        {
            return await _dbSet
                .Where(cs => cs.ClinicId == clinicId)
                .OrderBy(cs => cs.CreatedAt)
                .ToListAsync();
        }
    }
}

