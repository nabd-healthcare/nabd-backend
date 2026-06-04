using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nabd.Core.Entities.Medical.Consultations;
using Nabd.Core.Enums.Appointments;

namespace Nabd.Core.Interfaces.Repositories
{
	public interface IConsultationTypeRepository : IGenericRepository<ConsultationType>
	{
		Task<ConsultationType?> GetByEnumAsync(ConsultationTypeEnum consultationType);
	}
}
