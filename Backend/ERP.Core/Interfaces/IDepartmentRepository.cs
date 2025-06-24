using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task<Department> AddAsync(Department entity);
        Task<Department?> UpdateAsync(int id, Department entity);
        Task<bool> DeleteAsync(int id);
    }
}
