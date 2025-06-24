using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int maNV);
        Task<Employee> AddAsync(Employee entity);
        Task<Employee?> UpdateAsync(int maNV, Employee entity);
        Task<bool> DeleteAsync(int maNV);
    }
}
