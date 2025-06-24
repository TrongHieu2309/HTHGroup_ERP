using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IAllowanceService
    {
        Task<IEnumerable<AllowanceDto>> GetAllAllowancesAsync();
        Task<AllowanceDto?> GetAllowanceByIdAsync(int id);
        Task<AllowanceDto> CreateAllowanceAsync(AllowanceInputDto input);
        Task<AllowanceDto?> UpdateAllowanceAsync(int id, AllowanceInputDto input);
        Task<bool> DeleteAllowanceAsync(int id);
    }
}
