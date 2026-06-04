using Nabd.Core.Entities.Medical;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nabd.Core.Interfaces.Repositories.MedicationRepositories
{
    public interface IMedicationRepository : IGenericRepository<Medication>
    {

        Task<IEnumerable<Medication>> SearchMedicationsAsync(string searchTerm);
        Task<IEnumerable<Medication>> GetByManufacturerAsync(string manufacturer);
        Task<IEnumerable<Medication>> GetPrescriptionRequiredMedicationsAsync();
        Task<IEnumerable<Medication>> GetMostPrescribedMedicationsAsync(int count);
    }
}

