using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nabd.Core.Entities.Identity;
using Nabd.Core.DTOs;

namespace Nabd.Core.Interfaces.Repositories
{
	public interface IPatientRepository : IGenericRepository<Patient>
	{
		Task<Patient?> GetByIdWithDetailsAsync(Guid id);
		Task<Patient?> GetByEmailAsync(string email);
		Task<IEnumerable<Patient>> GetPatientsWithMedicalHistoryAsync();
        Task RemoveAsync(Patient patient, bool softDelete = true);
		Task<(IEnumerable<DoctorPatientDto> Patients, int TotalCount)> GetDoctorPatientsOptimizedAsync(
			Guid doctorId, 
			int pageNumber, 
			int pageSize);
		
		/// <summary>
		/// جلب المريض مع العنوان فقط (للبحث عن معامل/صيدليات قريبة)
		/// </summary>
		Task<Patient?> GetPatientWithAddressAsync(Guid patientId);
    }
}
