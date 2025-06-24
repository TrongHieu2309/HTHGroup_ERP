using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IExpenseRepository
    {
        Task<Expense> AddExpenseAsync(Expense entity);
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task<Expense?> GetExpenseByIdAsync(int id);
        Task<Expense?> UpdateExpenseAsync(int id, Expense entity);
        Task<bool> DeleteExpenseAsync(int id);
    }
}
