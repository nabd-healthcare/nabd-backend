using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nabd.Core.Entities.Medical.Schedules;
using Nabd.Core.Interfaces.Repositories;
using Nabd.Infrastructure.Data;

namespace Nabd.Infrastructure.Repositories.Doctors
{
    public class DoctorOverrideRepository : GenericRepository<DoctorOverride>, IDoctorOverrideRepository
    {
        public DoctorOverrideRepository(NabdDbContext context) : base(context) { }

        public async Task<IEnumerable<DoctorOverride>> GetByDoctorIdAsync(Guid doctorId)
        {
            return await _dbSet
                .Include(do_override => do_override.Doctor)
                .Where(do_override => do_override.DoctorId == doctorId)
                .OrderBy(do_override => do_override.StartTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<DoctorOverride>> GetByDoctorIdAndDateRangeAsync(
            Guid doctorId,
            DateTime startDate,
            DateTime endDate)
        {
            return await _dbSet
                .Where(do_override =>
                    do_override.DoctorId == doctorId
                    && do_override.StartTime < endDate  
                    && do_override.EndTime > startDate) 
                .OrderBy(do_override => do_override.StartTime)
                .ToListAsync();
        }

        public async Task<DoctorOverride?> GetOverrideAtTimeAsync(Guid doctorId, DateTime dateTime)
        {
            return await _dbSet
                .FirstOrDefaultAsync(do_override =>
                    do_override.DoctorId == doctorId
                    && dateTime >= do_override.StartTime
                    && dateTime <= do_override.EndTime);
        }
    }
}

