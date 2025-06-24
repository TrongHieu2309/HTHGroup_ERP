using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IStockInService
    {
        Task<IEnumerable<StockInDto>> GetAllAsync();
        Task<StockInDto?> GetByIdAsync(int id);
        Task<StockInDto> CreateAsync(StockInInputDto input);
        Task<StockInDto?> UpdateAsync(int id, StockInInputDto input);
        Task<bool> DeleteAsync(int id);
    }
}
