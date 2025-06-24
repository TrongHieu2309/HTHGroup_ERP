using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptDetailController(IReceiptDetailService service) : ControllerBase
    {
        // GET: api/receiptdetail
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAsync();
            return Ok(result);
        }

        // GET: api/receiptdetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await service.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        // POST: api/receiptdetail
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReceiptDetailInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.CreateAsync(input);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT: api/receiptdetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ReceiptDetailInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.UpdateAsync(id, input);
            return result is null ? NotFound() : Ok(result);
        }

        // DELETE: api/receiptdetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
