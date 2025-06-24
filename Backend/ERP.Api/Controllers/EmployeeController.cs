using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{maNV}")]
        public async Task<IActionResult> GetById(int maNV)
        {
            var result = await service.GetByIdAsync(maNV);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.CreateAsync(input);
            return CreatedAtAction(nameof(GetById), new { maNV = result.MaNV }, result);
        }

        [HttpPut("{maNV}")]
        public async Task<IActionResult> Update(int maNV, [FromBody] EmployeeInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.UpdateAsync(maNV, input);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpDelete("{maNV}")]
        public async Task<IActionResult> Delete(int maNV)
        {
            var deleted = await service.DeleteAsync(maNV);
            return deleted ? NoContent() : NotFound();
        }
    }
}
