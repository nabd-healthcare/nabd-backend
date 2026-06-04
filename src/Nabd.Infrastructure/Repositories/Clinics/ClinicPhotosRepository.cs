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
    public class ClinicPhotosRepository : GenericRepository<ClinicPhoto>, IClinicPhotosRepository
    {
        public ClinicPhotosRepository(NabdDbContext context) : base(context) { }

        public async Task<IEnumerable<ClinicPhoto>> GetClinicPhotosAsync(Guid clinicId)
        {
            return await _dbSet
                .Where(cp => cp.ClinicId == clinicId)
                .OrderBy(cp => cp.CreatedAt)
                .ToListAsync();
        }
    }
}

