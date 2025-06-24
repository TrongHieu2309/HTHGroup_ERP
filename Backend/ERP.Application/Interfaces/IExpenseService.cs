using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseDto>> GetAllExpensesAsync();
        Task<ExpenseDto?> GetExpenseByIdAsync(int id);
        Task<ExpenseDto> CreateExpenseAsync(ExpenseInputDto input);
        Task<ExpenseDto?> UpdateExpenseAsync(int id, ExpenseInputDto input);
        Task<bool> DeleteExpenseAsync(int id);
    }
}
