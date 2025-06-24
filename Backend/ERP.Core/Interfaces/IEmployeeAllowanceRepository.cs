using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IEmployeeAllowanceRepository
    {
        Task<IEnumerable<EmployeeAllowance>> GetAllAsync();
        Task<EmployeeAllowance?> GetByIdAsync(int id);
        Task<EmployeeAllowance> AddAsync(EmployeeAllowance entity);
        Task<EmployeeAllowance?> UpdateAsync(int id, EmployeeAllowance entity);
        Task<bool> DeleteAsync(int id);
    }
}
