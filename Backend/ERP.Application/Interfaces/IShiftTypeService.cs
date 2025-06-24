using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IShiftTypeService
    {
        Task<IEnumerable<ShiftTypeDto>> GetAllAsync();
        Task<ShiftTypeDto?> GetByIdAsync(int id);
        Task<ShiftTypeDto> CreateAsync(ShiftTypeInputDto input);
        Task<ShiftTypeDto?> UpdateAsync(int id, ShiftTypeInputDto input);
        Task<bool> DeleteAsync(int id);
    }
}
