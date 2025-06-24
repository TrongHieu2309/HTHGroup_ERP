using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class StockOutRepository(AppDbContext dbContext) : IStockOutRepository
    {
        public async Task<StockOut> AddStockOutAsync(StockOut entity)
        {
            await dbContext.StockOuts.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<StockOut>> GetAllAsync()
        {
            return await dbContext.StockOuts
                .Include(s => s.Inventory)
                .Include(s => s.StockOutDetails)
                .ToListAsync();
        }

        public async Task<StockOut?> GetByIdAsync(int maPhieuXuat)
        {
            return await dbContext.StockOuts
                .Include(s => s.Inventory)
                .Include(s => s.StockOutDetails)
                .FirstOrDefaultAsync(s => s.MaPhieuXuat == maPhieuXuat);
        }

        public async Task<StockOut?> UpdateStockOutAsync(int maPhieuXuat, StockOut entity)
        {
            var existing = await dbContext.StockOuts.FirstOrDefaultAsync(x => x.MaPhieuXuat == maPhieuXuat);
            if (existing is null) return null;

            existing.MaKho = entity.MaKho;
            existing.NguoiXuat = entity.NguoiXuat;
            existing.NgayXuat = entity.NgayXuat;
            existing.LyDoXuat = entity.LyDoXuat;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteStockOutAsync(int maPhieuXuat)
        {
            var stockOut = await dbContext.StockOuts.FirstOrDefaultAsync(x => x.MaPhieuXuat == maPhieuXuat);
            if (stockOut is null) return false;

            dbContext.StockOuts.Remove(stockOut);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
