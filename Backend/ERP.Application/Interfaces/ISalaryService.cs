using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface ISalaryService
    {
        Task<IEnumerable<SalaryDto>> GetAllSalariesAsync();
        Task<SalaryDto?> GetSalaryByIdAsync(int id);
        Task<SalaryDto> CreateSalaryAsync(SalaryInputDto input);
        Task<SalaryDto?> UpdateSalaryAsync(int id, SalaryInputDto input);
        Task<bool> DeleteSalaryAsync(int id);
    }
}
