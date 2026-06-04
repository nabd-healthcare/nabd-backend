using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nabd.Core.Entities.Identity;
using Nabd.Core.Entities.Medical.Consultations;

namespace Nabd.Core.Interfaces.Repositories
{
	public interface IConsultationRecordRepository : IGenericRepository<ConsultationRecord>
	{
		Task<ConsultationRecord?> GetByAppointmentIdAsync(Guid appointmentId);
	}
}
