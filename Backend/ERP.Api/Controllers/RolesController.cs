using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IRolesService service) : ControllerBase
    {
        // GET: api/roles
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllRolesAsync();
            return Ok(result);
        }

        // GET: api/roles/{id}
        [HttpGet("{maVaiTro}")]
        public async Task<IActionResult> GetById(string maVaiTro)
        {
            var result = await service.GetRoleByIdAsync(maVaiTro);
            return result is null ? NotFound() : Ok(result);
        }

        // POST: api/roles
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolesInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.CreateRoleAsync(input);
            return CreatedAtAction(nameof(GetById), new { maVaiTro = result.MaVaiTro }, result);
        }

        // PUT: api/roles/{id}
        [HttpPut("{maVaiTro}")]
        public async Task<IActionResult> Update(string maVaiTro, [FromBody] RolesInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.UpdateRoleAsync(maVaiTro, input);
            return result is null ? NotFound() : Ok(result);
        }

        // DELETE: api/roles/{id}
        [HttpDelete("{maVaiTro}")]
        public async Task<IActionResult> Delete(string maVaiTro)
        {
            var success = await service.DeleteRoleAsync(maVaiTro);
            return success ? NoContent() : NotFound();
        }
    }
}
