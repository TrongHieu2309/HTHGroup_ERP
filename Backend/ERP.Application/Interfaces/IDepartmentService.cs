using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllAsync();
        Task<DepartmentDto?> GetByIdAsync(int id);
        Task<DepartmentDto> CreateAsync(DepartmentInputDto input);
        Task<DepartmentDto?> UpdateAsync(int id, DepartmentInputDto input);
        Task<bool> DeleteAsync(int id);
    }
}
