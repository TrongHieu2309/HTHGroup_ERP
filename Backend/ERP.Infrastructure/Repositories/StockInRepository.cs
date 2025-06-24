using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class StockInRepository(AppDbContext dbContext) : IStockInRepository
    {
        // Thêm phiếu nhập mới
        public async Task<StockIn> AddStockInAsync(StockIn entity)
        {
            await dbContext.StockIns.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        // Lấy tất cả phiếu nhập
        public async Task<IEnumerable<StockIn>> GetAllStockInsAsync()
        {
            return await dbContext.StockIns
                .Include(x => x.Provider)
                .Include(x => x.Inventory)
                .Include(x => x.StockInDetails)
                .ToListAsync();
        }

        // Lấy phiếu nhập theo ID
        public async Task<StockIn?> GetStockInByIdAsync(int maPhieuNhap)
        {
            return await dbContext.StockIns
                .Include(x => x.Provider)
                .Include(x => x.Inventory)
                .Include(x => x.StockInDetails)
                .FirstOrDefaultAsync(x => x.MaPhieuNhap == maPhieuNhap);
        }

        // Cập nhật phiếu nhập
        public async Task<StockIn?> UpdateStockInAsync(int maPhieuNhap, StockIn entity)
        {
            var existing = await dbContext.StockIns.FirstOrDefaultAsync(x => x.MaPhieuNhap == maPhieuNhap);
            if (existing is null) return null;

            existing.MaNCC = entity.MaNCC;
            existing.MaKho = entity.MaKho;
            existing.NgayNhap = entity.NgayNhap;
            existing.GhiChu = entity.GhiChu;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        // Xoá phiếu nhập
        public async Task<bool> DeleteStockInAsync(int maPhieuNhap)
        {
            var stockIn = await dbContext.StockIns.FirstOrDefaultAsync(x => x.MaPhieuNhap == maPhieuNhap);
            if (stockIn is null) return false;

            dbContext.StockIns.Remove(stockIn);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
