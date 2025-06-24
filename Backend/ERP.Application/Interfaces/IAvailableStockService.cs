using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IAvailableStockService
    {
        Task<IEnumerable<AvailableStockDto>> GetAllAsync();
        Task<AvailableStockDto?> GetByIdAsync(int id);
        Task<AvailableStockDto> CreateAsync(AvailableStockInputDto input);
        Task<AvailableStockDto?> UpdateAsync(int id, AvailableStockInputDto input);
        Task<bool> DeleteAsync(int id);
    }
}
