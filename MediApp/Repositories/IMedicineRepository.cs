using MediApp.Entities;
using MediApp.ViewModels;

namespace MediApp.Repositories
{
    public interface IMedicineRepository
    {
        Task<List<Medicine>> GetAllAsync(CancellationToken cancellationToken);
        Task<Guid> AddAsync(MedicineRecord medicineRecord, CancellationToken cancellationToken);
        Task DeleteAsync(Guid guid, CancellationToken cancellationToken);
    }
}
