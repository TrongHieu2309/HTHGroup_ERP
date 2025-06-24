using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IStockOutDetailRepository
    {
        Task<StockOutDetail> AddStockOutDetailAsync(StockOutDetail entity);
        Task<IEnumerable<StockOutDetail>> GetAllAsync();
        Task<StockOutDetail?> GetByIdAsync(int id);
        Task<IEnumerable<StockOutDetail>> GetByStockOutIdAsync(int maPhieuXuat);
        Task<StockOutDetail?> UpdateStockOutDetailAsync(int id, StockOutDetail entity);
        Task<bool> DeleteStockOutDetailAsync(int id);
    }
}
