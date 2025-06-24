using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IStockInDetailRepository
    {
        Task<StockInDetail> AddStockInDetailAsync(StockInDetail entity);
        Task<IEnumerable<StockInDetail>> GetAllAsync();
        Task<IEnumerable<StockInDetail>> GetByStockInIdAsync(int maPhieuNhap);
        Task<StockInDetail?> GetByIdAsync(int id);
        Task<StockInDetail?> UpdateStockInDetailAsync(int id, StockInDetail entity);
        Task<bool> DeleteStockInDetailAsync(int id);
    }
}
