using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockOutDetailController(IStockOutDetailService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var detail = await service.GetByIdAsync(id);
            if (detail == null) return NotFound();
            return Ok(detail);
        }

        [HttpGet("by-stockout/{maPhieuXuat}")]
        public async Task<IActionResult> GetByStockOutId(int maPhieuXuat)
        {
            var details = await service.GetByStockOutIdAsync(maPhieuXuat);
            return Ok(details);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StockOutDetailInputDto input)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await service.CreateAsync(input);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StockOutDetailInputDto input)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await service.UpdateAsync(id, input);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
