using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllowanceController(IAllowanceService service) : ControllerBase
    {
        // GET: api/allowances
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAllowancesAsync();
            return Ok(result);
        }

        // GET: api/allowances/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await service.GetAllowanceByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        // POST: api/allowances
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AllowanceInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.CreateAllowanceAsync(input);
            return CreatedAtAction(nameof(GetById), new { id = result.MaPC }, result);
        }

        // PUT: api/allowances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AllowanceInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.UpdateAllowanceAsync(id, input);
            return result is null ? NotFound() : Ok(result);
        }

        // DELETE: api/allowances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await service.DeleteAllowanceAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
