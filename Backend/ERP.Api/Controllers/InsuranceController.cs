using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController(IInsuranceService service) : ControllerBase
    {
        // GET: api/insurance
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var insurances = await service.GetAllInsurancesAsync();
            return Ok(insurances);
        }

        // GET: api/insurance/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var insurance = await service.GetInsuranceByIdAsync(id);
            if (insurance == null)
                return NotFound($"Không tìm thấy bảo hiểm với mã {id}.");

            return Ok(insurance);
        }

        // POST: api/insurance
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InsuranceInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await service.CreateInsuranceAsync(input);
            return CreatedAtAction(nameof(GetById), new { id = created.MaBH }, created);
        }

        // PUT: api/insurance/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InsuranceInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await service.UpdateInsuranceAsync(id, input);
            if (updated == null)
                return NotFound($"Không tìm thấy bảo hiểm với mã {id}.");

            return Ok(updated);
        }

        // DELETE: api/insurance/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await service.DeleteInsuranceAsync(id);
            if (!success)
                return NotFound($"Không tìm thấy bảo hiểm với mã {id}.");

            return NoContent();
        }
    }
}
