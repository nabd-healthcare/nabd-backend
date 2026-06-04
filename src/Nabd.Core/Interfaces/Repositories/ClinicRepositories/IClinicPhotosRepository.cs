using Nabd.Core.Entities.External.Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nabd.Core.Interfaces.Repositories.ClinicRepositories
{
    public interface IClinicPhotosRepository : IGenericRepository<ClinicPhoto>
    {
        Task<IEnumerable<ClinicPhoto>> GetClinicPhotosAsync(Guid clinicId);
    }
}
