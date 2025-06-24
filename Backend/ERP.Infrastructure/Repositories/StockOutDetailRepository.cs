using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class StockOutDetailRepository(AppDbContext dbContext) : IStockOutDetailRepository
    {
        // Thêm mới chi tiết xuất kho
        public async Task<StockOutDetail> AddStockOutDetailAsync(StockOutDetail entity)
        {
            await dbContext.StockOutDetails.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        // Lấy tất cả chi tiết xuất kho
        public async Task<IEnumerable<StockOutDetail>> GetAllAsync()
        {
            return await dbContext.StockOutDetails
                .Include(d => d.StockOut)
                .Include(d => d.Product)
                .ToListAsync();
        }

        // Lấy chi tiết xuất kho theo ID
        public async Task<StockOutDetail?> GetByIdAsync(int id)
        {
            return await dbContext.StockOutDetails
                .Include(d => d.StockOut)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // Lấy danh sách chi tiết xuất kho theo mã phiếu xuất
        public async Task<IEnumerable<StockOutDetail>> GetByStockOutIdAsync(int maPhieuXuat)
        {
            return await dbContext.StockOutDetails
                .Include(d => d.Product)
                .Where(d => d.MaPhieuXuat == maPhieuXuat)
                .ToListAsync();
        }

        // Cập nhật chi tiết xuất kho
        public async Task<StockOutDetail?> UpdateStockOutDetailAsync(int id, StockOutDetail entity)
        {
            var existing = await dbContext.StockOutDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null) return null;

            existing.MaPhieuXuat = entity.MaPhieuXuat;
            existing.MaSP = entity.MaSP;
            existing.SoLuongXuat = entity.SoLuongXuat;
            existing.GhiChu = entity.GhiChu;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        // Xoá chi tiết xuất kho
        public async Task<bool> DeleteStockOutDetailAsync(int id)
        {
            var detail = await dbContext.StockOutDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (detail == null) return false;

            dbContext.StockOutDetails.Remove(detail);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
