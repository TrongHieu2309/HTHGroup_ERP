using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class StockInDetailRepository(AppDbContext dbContext) : IStockInDetailRepository
    {
        public async Task<StockInDetail> AddStockInDetailAsync(StockInDetail entity)
        {
            await dbContext.StockInDetails.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<StockInDetail>> GetAllAsync()
        {
            return await dbContext.StockInDetails
                .Include(d => d.Product)
                .Include(d => d.StockIn)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockInDetail>> GetByStockInIdAsync(int maPhieuNhap)
        {
            return await dbContext.StockInDetails
                .Include(d => d.Product)
                .Where(d => d.MaPhieuNhap == maPhieuNhap)
                .ToListAsync();
        }

        public async Task<StockInDetail?> GetByIdAsync(int id)
        {
            return await dbContext.StockInDetails
                .Include(d => d.Product)
                .Include(d => d.StockIn)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<StockInDetail?> UpdateStockInDetailAsync(int id, StockInDetail entity)
        {
            var existing = await dbContext.StockInDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null) return null;

            existing.MaPhieuNhap = entity.MaPhieuNhap;
            existing.MaSP = entity.MaSP;
            existing.SoLuongNhap = entity.SoLuongNhap;
            existing.DonGia = entity.DonGia;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteStockInDetailAsync(int id)
        {
            var detail = await dbContext.StockInDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (detail == null) return false;

            dbContext.StockInDetails.Remove(detail);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
