using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class RevenueRepository(AppDbContext dbContext) : IRevenueRepository
    {
        // Thêm mới Thu
        public async Task<Revenue> AddRevenueAsync(Revenue entity)
        {
            await dbContext.Revenues.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        // GET ALL Revenues
        public async Task<IEnumerable<Revenue>> GetRevenues()
        {
            return await dbContext.Revenues
                                 .Include(r => r.Employee)
                                 .ToListAsync();
        }

        // GET Revenue by Id
        public async Task<Revenue?> GetRevenueByIdAsync(int mathu)
        {
            return await dbContext.Revenues
                                  .Include(r => r.Employee)
                                  .FirstOrDefaultAsync(r => r.MaThu == mathu);
        }

        // UPDATE Thu
        public async Task<Revenue?> UpdateRevenueAsync(int mathu, Revenue entity)
        {
            var existing = await dbContext.Revenues.FirstOrDefaultAsync(r => r.MaThu == mathu);
            if (existing is null) return null;

            existing.MaNV = entity.MaNV;
            existing.NgayThu = entity.NgayThu;
            existing.NoiDung = entity.NoiDung;
            existing.SoTien = entity.SoTien;
            existing.NguoiThu = entity.NguoiThu;
            existing.GhiChu = entity.GhiChu;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        // DELETE Thu
        public async Task<bool> DeleteRevenueAsync(int mathu)
        {
            var revenue = await dbContext.Revenues.FirstOrDefaultAsync(r => r.MaThu == mathu);
            if (revenue is null) return false;

            dbContext.Revenues.Remove(revenue);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
