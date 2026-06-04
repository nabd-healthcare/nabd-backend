using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nabd.Core.Entities.Identity;
using Nabd.Core.Enums.Doctor;
using Nabd.Core.Enums;

namespace Nabd.Core.Interfaces.Repositories
{
	public interface IDoctorRepository : IGenericRepository<Doctor>
	{
		Task<Doctor?> GetByIdWithDetailsAsync(Guid id);
		Task<Doctor?> GetByIdWithClinicAsync(Guid id);
		Task<Doctor?> GetByIdWithAvailabilitiesAsync(Guid id);
		Task<Doctor?> GetByEmailAsync(string email);
		Task<IEnumerable<Doctor>> GetBySpecialtyAsync(MedicalSpecialty specialty);
		Task<IEnumerable<Doctor>> GetVerifiedDoctorsAsync();
		Task<IEnumerable<Doctor>> GetDoctorsByGovernorateAsync(Governorate governorate);
		Task<IEnumerable<Doctor>> SearchDoctorsAsync(
			string? searchTerm = null,
			MedicalSpecialty? specialty = null,
			Governorate? governorate = null,
			int? minYearsOfExperience = null,
			decimal? maxConsultationFee = null,
			double? minRating = null
		);
		Task<bool> IsAvailableAtAsync(Guid doctorId, DateTime dateTime);
		
		/// <summary>
		/// جلب الدكاترة الموثقين مع كل البيانات المطلوبة للـ list (optimized for performance)
		/// </summary>
		Task<IEnumerable<Doctor>> GetVerifiedDoctorsWithDetailsForListAsync();
	}
}
