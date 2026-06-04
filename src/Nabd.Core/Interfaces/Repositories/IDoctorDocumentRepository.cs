using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nabd.Core.Entities.Common;
using Nabd.Core.Enums;

namespace Nabd.Core.Interfaces.Repositories
{
	public interface IDoctorDocumentRepository : IGenericRepository<DoctorDocument>
	{
		Task<IEnumerable<DoctorDocument>> GetByDoctorIdAsync(Guid doctorId);
		Task<IEnumerable<DoctorDocument>> GetPendingDocumentsAsync();
		Task<IEnumerable<DoctorDocument>> GetByStatusAsync(VerificationDocumentStatus status);
	}
}
