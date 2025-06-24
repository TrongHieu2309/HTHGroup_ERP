using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController(IInventoryService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllInventoriesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await service.GetInventoryByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InventoryInputDto input)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await service.CreateInventoryAsync(input);
            return CreatedAtAction(nameof(GetById), new { id = result.MaKho }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InventoryInputDto input)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await service.UpdateInventoryAsync(id, input);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await service.DeleteInventoryAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
