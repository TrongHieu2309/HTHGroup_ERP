using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IStockInRepository
    {
        // Thêm phiếu nhập mới
        Task<StockIn> AddStockInAsync(StockIn entity);

        // Lấy tất cả phiếu nhập
        Task<IEnumerable<StockIn>> GetAllStockInsAsync();

        // Lấy phiếu nhập theo ID
        Task<StockIn?> GetStockInByIdAsync(int maPhieuNhap);

        // Cập nhật phiếu nhập
        Task<StockIn?> UpdateStockInAsync(int maPhieuNhap, StockIn entity);

        // Xoá phiếu nhập
        Task<bool> DeleteStockInAsync(int maPhieuNhap);
    }
}
