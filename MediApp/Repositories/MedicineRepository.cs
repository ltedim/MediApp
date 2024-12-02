using MediApp.Entities;
using MediApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MediApp.Repositories
{
    public class MedicineRepository(MedsDbContext dbContext) : IMedicineRepository
    {
        public async Task<List<Medicine>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await dbContext.Meds.ToListAsync(cancellationToken);
        }

        public async Task<Guid> AddAsync(MedicineRecord medicineRecord, CancellationToken cancellationToken)
        {
            if (medicineRecord.Quantity < 1)
            {
                throw new ArgumentException("Invalid quantity");
            }

            var newMed = new Medicine
            {
                Name = medicineRecord.Name,
                Quantity = medicineRecord.Quantity,
            };
            await dbContext.Meds.AddAsync(newMed, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return newMed.Id;
        }

        public async Task DeleteAsync(Guid guid, CancellationToken cancellationToken)
        {
            var med = await dbContext.Meds.FindAsync([guid], cancellationToken);
            if (med == null)
            {
                throw new ArgumentException("Medicine not found.");
            }

            dbContext.Meds.Remove(med);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
