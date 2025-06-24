using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IStockInDetailService
    {
        Task<IEnumerable<StockInDetailDto>> GetAllAsync();
        Task<IEnumerable<StockInDetailDto>> GetByStockInIdAsync(int maPhieuNhap);
        Task<StockInDetailDto?> GetByIdAsync(int id);
        Task<StockInDetailDto> AddAsync(StockInDetailInputDto dto);
        Task<StockInDetailDto?> UpdateAsync(int id, StockInDetailInputDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
