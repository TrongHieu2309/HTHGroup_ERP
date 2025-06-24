using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController(ISectionService service) : ControllerBase
    {
        // GET: api/section
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllSectionsAsync();
            return Ok(result);
        }

        // GET: api/section/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await service.GetSectionByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        // POST: api/section
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SectionInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.CreateSectionAsync(input);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT: api/section/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SectionInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.UpdateSectionAsync(id, input);
            return result is null ? NotFound() : Ok(result);
        }

        // DELETE: api/section/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await service.DeleteSectionAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
