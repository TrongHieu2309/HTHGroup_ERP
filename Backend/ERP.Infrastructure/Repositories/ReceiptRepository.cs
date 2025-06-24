using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class ReceiptRepository(AppDbContext dbContext) : IReceiptRepository
    {
        public async Task<IEnumerable<Receipt>> GetAllAsync()
        {
            return await dbContext.Receipts
                                  .Include(r => r.Customer)
                                  .Include(r => r.ReceiptDetails)
                                  .ToListAsync();
        }

        public async Task<Receipt?> GetByIdAsync(int maHD)
        {
            return await dbContext.Receipts
                                  .Include(r => r.Customer)
                                  .Include(r => r.ReceiptDetails)
                                  .FirstOrDefaultAsync(r => r.MaHD == maHD);
        }

        public async Task<Receipt> AddAsync(Receipt entity)
        {
            await dbContext.Receipts.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Receipt?> UpdateAsync(int maHD, Receipt entity)
        {
            var existing = await dbContext.Receipts.FindAsync(maHD);
            if (existing == null) return null;

            existing.MaKH = entity.MaKH;
            existing.LoaiHD = entity.LoaiHD;
            existing.NgayLap = entity.NgayLap;
            existing.NguoiLap = entity.NguoiLap;
            existing.TongTien = entity.TongTien;
            existing.TrangThai = entity.TrangThai;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int maHD)
        {
            var entity = await dbContext.Receipts.FindAsync(maHD);
            if (entity == null) return false;

            dbContext.Receipts.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
