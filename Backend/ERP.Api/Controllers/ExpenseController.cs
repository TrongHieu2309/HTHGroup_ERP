using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController(IExpenseService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllExpensesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await service.GetExpenseByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExpenseInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.CreateExpenseAsync(input);
            return CreatedAtAction(nameof(GetById), new { id = result.MaChi }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ExpenseInputDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.UpdateExpenseAsync(id, input);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await service.DeleteExpenseAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
