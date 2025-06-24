using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftTypeController(IShiftTypeService service) : ControllerBase
    {
        // GET: api/ShiftType
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAsync();
            return Ok(result);
        }

        // GET: api/ShiftType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await service.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        // POST: api/ShiftType
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShiftTypeInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await service.CreateAsync(input);
            return CreatedAtAction(nameof(GetById), new { id = created.MaLoaiCa }, created);
        }

        // PUT: api/ShiftType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ShiftTypeInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await service.UpdateAsync(id, input);
            return updated is null ? NotFound() : Ok(updated);
        }

        // DELETE: api/ShiftType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
