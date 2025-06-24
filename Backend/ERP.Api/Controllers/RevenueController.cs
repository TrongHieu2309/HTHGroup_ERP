using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController(IRevenueService service) : ControllerBase
    {
        // GET: api/revenue
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllRevenuesAsync();
            return Ok(result);
        }

        // GET: api/revenue/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await service.GetRevenueByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        // POST: api/revenue
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RevenueInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.CreateRevenueAsync(input);
            return CreatedAtAction(nameof(GetById), new { id = result.MaThu }, result);
        }

        // PUT: api/revenue/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RevenueInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.UpdateRevenueAsync(id, input);
            return result is null ? NotFound() : Ok(result);
        }

        // DELETE: api/revenue/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await service.DeleteRevenueAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
