using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController(IProviderService providerService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var providers = await providerService.GetAllProvidersAsync();
            return Ok(providers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var provider = await providerService.GetProviderByIdAsync(id);
            return provider is null ? NotFound() : Ok(provider);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProviderInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await providerService.AddProviderAsync(input);
            return CreatedAtAction(nameof(GetById), new { id = created.MaNCC }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProviderInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await providerService.UpdateProviderAsync(id, input);
            return updated is null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await providerService.DeleteProviderAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
