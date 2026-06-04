using Nabd.Core.Entities.Medical;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nabd.Core.Interfaces.Repositories
{
    public interface IDispensingRecordRepository : IGenericRepository<DispensingRecord>
    {
        Task<IEnumerable<DispensingRecord>> GetByPrescriptionIdAsync(Guid prescriptionId);

    }
}
