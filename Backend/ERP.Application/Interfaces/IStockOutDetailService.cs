using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IStockOutDetailService
    {
        Task<IEnumerable<StockOutDetailDto>> GetAllAsync();
        Task<StockOutDetailDto?> GetByIdAsync(int id);
        Task<IEnumerable<StockOutDetailDto>> GetByStockOutIdAsync(int maPhieuXuat);
        Task<StockOutDetailDto> CreateAsync(StockOutDetailInputDto input);
        Task<StockOutDetailDto?> UpdateAsync(int id, StockOutDetailInputDto input);
        Task<bool> DeleteAsync(int id);
    }
}
