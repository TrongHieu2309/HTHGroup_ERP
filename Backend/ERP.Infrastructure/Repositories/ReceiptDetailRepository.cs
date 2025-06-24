using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class ReceiptDetailRepository(AppDbContext dbContext) : IReceiptDetailRepository
    {
        public async Task<IEnumerable<ReceiptDetail>> GetAllAsync()
        {
            return await dbContext.ReceiptDetails
                .Include(rd => rd.Receipt)
                .Include(rd => rd.Product)
                .ToListAsync();
        }

        public async Task<ReceiptDetail?> GetByIdAsync(int id)
        {
            return await dbContext.ReceiptDetails
                .Include(rd => rd.Receipt)
                .Include(rd => rd.Product)
                .FirstOrDefaultAsync(rd => rd.Id == id);
        }

        public async Task<ReceiptDetail> AddAsync(ReceiptDetail entity)
        {
            await dbContext.ReceiptDetails.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<ReceiptDetail?> UpdateAsync(int id, ReceiptDetail entity)
        {
            var existing = await dbContext.ReceiptDetails.FindAsync(id);
            if (existing is null) return null;

            existing.MaHD = entity.MaHD;
            existing.MaSP = entity.MaSP;
            existing.SoLuong = entity.SoLuong;
            existing.DonGia = entity.DonGia;
            existing.ChietKhau = entity.ChietKhau;
            existing.VAT = entity.VAT;
            existing.GhiChu = entity.GhiChu;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await dbContext.ReceiptDetails.FindAsync(id);
            if (entity is null) return false;

            dbContext.ReceiptDetails.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
