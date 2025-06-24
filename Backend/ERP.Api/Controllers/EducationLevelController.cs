using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationLevelController(IEducationLevelService service) : ControllerBase
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
            var result = await service.GetByIdAsync(id);
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EducationLevelInputDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.MaTDHV }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EducationLevelInputDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await service.UpdateAsync(id, dto);
            if (result is null) return NotFound();
            return Ok(result);
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
