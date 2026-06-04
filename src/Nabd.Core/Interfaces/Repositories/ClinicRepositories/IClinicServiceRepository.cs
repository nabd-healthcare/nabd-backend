using Nabd.Core.Entities.External.Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nabd.Core.Interfaces.Repositories.ClinicRepositories
{
    public interface IClinicServiceRepository : IGenericRepository<ClinicService>
    {
        Task<IEnumerable<ClinicService>> GetClinicServicesAsync(Guid clinicId);
    }
}
