using Microsoft.EntityFrameworkCore;
using Nabd.Core.Entities.Medical.Consultations;
using Nabd.Core.Interfaces.Repositories;
using Nabd.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace Nabd.Infrastructure.Repositories.Medical
{
    public class ConsultationRecordRepository : GenericRepository<ConsultationRecord>, IConsultationRecordRepository
    {
        public ConsultationRecordRepository(NabdDbContext context) : base(context) { }
        public async Task<ConsultationRecord?> GetByAppointmentIdAsync(Guid appointmentId)
        {
            return await _dbSet
                .Include(cr => cr.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(cr => cr.Appointment)
                    .ThenInclude(a => a.Doctor)
                .FirstOrDefaultAsync(cr => cr.AppointmentId == appointmentId);
        }
    }
}

