using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IEmployeeAllowanceService
    {
        Task<IEnumerable<EmployeeAllowanceDto>> GetAllAsync();
        Task<EmployeeAllowanceDto?> GetByIdAsync(int id);
        Task<EmployeeAllowanceDto> AddAsync(EmployeeAllowanceInputDto dto);
        Task<EmployeeAllowanceDto?> UpdateAsync(int id, EmployeeAllowanceInputDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
