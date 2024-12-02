using MediApp.Entities;
using MediApp.Repositories;
using MediApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MediApp.Controllers
{
    [Route("api/meds")]
    [ApiController]
    public class MedsController(IMedicineRepository medicineRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<List<Medicine>> Get(CancellationToken cancellationToken)
        {
            return await medicineRepository.GetAllAsync(cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post(MedicineRecord med, CancellationToken cancellationToken)
        {
            try
            {
                return await medicineRepository.AddAsync(med, cancellationToken);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await medicineRepository.DeleteAsync(id, cancellationToken);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
