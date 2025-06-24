using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await service.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await service.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductInputDto input)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await service.CreateAsync(input);
            return CreatedAtAction(nameof(GetById), new { id = created.MaSP }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductInputDto input)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updated = await service.UpdateAsync(id, input);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
