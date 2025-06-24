using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IStockOutService
    {
        Task<IEnumerable<StockOutDto>> GetAllAsync();
        Task<StockOutDto?> GetByIdAsync(int id);
        Task<StockOutDto> CreateAsync(StockOutInputDto input);
        Task<StockOutDto?> UpdateAsync(int id, StockOutInputDto input);
        Task<bool> DeleteAsync(int id);
    }
}
