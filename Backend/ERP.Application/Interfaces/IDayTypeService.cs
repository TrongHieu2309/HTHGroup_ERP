using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IDayTypeService
    {
        Task<IEnumerable<DayTypeDto>> GetAllAsync();
        Task<DayTypeDto?> GetByIdAsync(int id);
        Task<DayTypeDto> CreateAsync(DayTypeInputDto inputDto);
        Task<DayTypeDto?> UpdateAsync(int id, DayTypeInputDto inputDto);
        Task<bool> DeleteAsync(int id);
    }
}
