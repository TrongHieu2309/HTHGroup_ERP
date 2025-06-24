using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(int maNV);
        Task<EmployeeDto> CreateAsync(EmployeeInputDto input);
        Task<EmployeeDto?> UpdateAsync(int maNV, EmployeeInputDto input);
        Task<bool> DeleteAsync(int maNV);
    }
}
