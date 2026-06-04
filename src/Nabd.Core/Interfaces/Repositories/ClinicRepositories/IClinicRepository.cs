using Nabd.Core.Entities.External.Clinic;
using Nabd.Core.Enums;
using Nabd.Core.Enums.Clinic;
using Nabd.Core.Enums.Doctor;
using Nabd.Core.Enums.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nabd.Core.Interfaces.Repositories.ClinicRepositories
{
    public interface IClinicRepository : IGenericRepository<Clinic>
    {
        Task<Clinic?> GetClinicByDoctorIdAsync(Guid doctorId);
        Task<IEnumerable<Clinic>> GetClinicsNearLocationAsync(double latitude, double longitude, double radiusInKm);
    }
}