using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nabd.Core.Entities.Common;
using Nabd.Core.Entities.Shared;
using Nabd.Core.Enums;

namespace Nabd.Core.Interfaces.Repositories
{
	public interface IMedicalHistoryItemRepository : IGenericRepository<MedicalHistoryItem>
	{
		Task<IEnumerable<MedicalHistoryItem>> GetByPatientIdAsync(Guid patientId);
		Task<IEnumerable<MedicalHistoryItem>> GetByTypeAsync(Guid patientId, MedicalHistoryType type);
	}
}
