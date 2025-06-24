using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IExtraShiftService
    {
        Task<IEnumerable<ExtraShiftDto>> GetAllAsync();
        Task<ExtraShiftDto?> GetByIdAsync(int id);
        Task<ExtraShiftDto> CreateAsync(ExtraShiftInputDto input);
        Task<ExtraShiftDto?> UpdateAsync(int id, ExtraShiftInputDto input);
        Task<bool> DeleteAsync(int id);
    }
}
