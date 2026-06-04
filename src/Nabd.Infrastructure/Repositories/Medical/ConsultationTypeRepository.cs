using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nabd.Core.Entities.Medical.Consultations;
using Nabd.Core.Enums.Appointments;
using Nabd.Core.Interfaces.Repositories;
using Nabd.Infrastructure.Data;

namespace Nabd.Infrastructure.Repositories.Medical
{
    public class ConsultationTypeRepository : GenericRepository<ConsultationType>, IConsultationTypeRepository
    {
        public ConsultationTypeRepository(NabdDbContext context) : base(context) { }

        public async Task<ConsultationType?> GetByEnumAsync(ConsultationTypeEnum consultationType)
        {
            return await _dbSet
                .Include(ct => ct.Consultations)
                    .ThenInclude(dc => dc.Doctor)
                .FirstOrDefaultAsync(ct => ct.ConsultationTypeEnum == consultationType);
        }
    }
}

