using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoriseController(IAuthoriseService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{maVaiTro}/{maQuyen}")]
        public async Task<IActionResult> GetById(string maVaiTro, int maQuyen)
        {
            var result = await service.GetByIdAsync(maVaiTro, maQuyen);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AuthoriseInputDto input)
        {
            var result = await service.CreateAsync(input);
            return CreatedAtAction(nameof(GetById), new { maVaiTro = result.MaVaiTro, maQuyen = result.MaQuyen }, result);
        }

        [HttpPut("{maVaiTro}/{maQuyen}")]
        public async Task<IActionResult> Update(string maVaiTro, int maQuyen, [FromBody] AuthoriseInputDto input)
        {
            var result = await service.UpdateAsync(maVaiTro, maQuyen, input);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpDelete("{maVaiTro}/{maQuyen}")]
        public async Task<IActionResult> Delete(string maVaiTro, int maQuyen)
        {
            var success = await service.DeleteAsync(maVaiTro, maQuyen);
            return success ? NoContent() : NotFound();
        }
    }
}
