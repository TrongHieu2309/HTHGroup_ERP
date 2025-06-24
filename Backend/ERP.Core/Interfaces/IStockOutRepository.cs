using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IStockOutRepository
    {
        Task<StockOut> AddStockOutAsync(StockOut entity);
        Task<IEnumerable<StockOut>> GetAllAsync();
        Task<StockOut?> GetByIdAsync(int maPhieuXuat);
        Task<StockOut?> UpdateStockOutAsync(int maPhieuXuat, StockOut entity);
        Task<bool> DeleteStockOutAsync(int maPhieuXuat);
    }
}
