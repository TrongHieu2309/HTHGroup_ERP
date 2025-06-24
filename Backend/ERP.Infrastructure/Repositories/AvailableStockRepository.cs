using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class AvailableStockRepository(AppDbContext dbContext) : IAvailableStockRepository
    {
        public async Task<IEnumerable<AvailableStock>> GetAllAsync()
        {
            return await dbContext.AvailableStocks
                .Include(a => a.Product)
                .Include(a => a.Inventory)
                .ToListAsync();
        }

        public async Task<AvailableStock?> GetByIdAsync(int id)
        {
            return await dbContext.AvailableStocks
                .Include(a => a.Product)
                .Include(a => a.Inventory)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<AvailableStock> AddAsync(AvailableStock stock)
        {
            await dbContext.AvailableStocks.AddAsync(stock);
            await dbContext.SaveChangesAsync();
            return stock;
        }

        public async Task<AvailableStock?> UpdateAsync(int id, AvailableStock stock)
        {
            var existing = await dbContext.AvailableStocks.FindAsync(id);
            if (existing is null) return null;

            existing.MaSP = stock.MaSP;
            existing.TenSP = stock.TenSP;
            existing.MaKho = stock.MaKho;
            existing.SoLuongTon = stock.SoLuongTon;
            existing.NgayCapNhat = stock.NgayCapNhat;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await dbContext.AvailableStocks.FindAsync(id);
            if (existing is null) return false;

            dbContext.AvailableStocks.Remove(existing);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
