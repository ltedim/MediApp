using MediApp;
using MediApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MediAppTests
{
    public class MedicineRepositoryTest
    {
        private MedicineRepository _medicineRepo;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MedsDbContext>()
            .UseInMemoryDatabase(databaseName: "meds")
            .Options;

            _medicineRepo = new MedicineRepository(new MedsDbContext(options));
        }

        [Test]
        public async Task GetAllTest()
        {
            var result = await _medicineRepo.GetAllAsync(CancellationToken.None);

            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public async Task AddTest()
        {
            var result = await _medicineRepo.AddAsync(
                new MediApp.ViewModels.MedicineRecord("test", 5),
                CancellationToken.None);
            Assert.IsInstanceOf<Guid>(result);
            var resultCount = await _medicineRepo.GetAllAsync(CancellationToken.None);

            Assert.IsTrue(resultCount.Any(x => x.Id == result));
        }

        [Test]
        public async Task DeleteTest()
        {
            var result = await _medicineRepo.AddAsync(
                new MediApp.ViewModels.MedicineRecord("test", 5),
                CancellationToken.None);
            Assert.IsInstanceOf<Guid>(result);

            await _medicineRepo.DeleteAsync(result, CancellationToken.None);

            var resultCount = await _medicineRepo.GetAllAsync(CancellationToken.None);

            Assert.IsFalse(resultCount.Any(x => x.Id == result));
        }
    }
}