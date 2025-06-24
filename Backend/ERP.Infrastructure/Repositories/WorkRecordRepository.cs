using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class WorkRecordRepository(AppDbContext dbContext) : IWorkRecordRepository
    {
        public async Task<IEnumerable<WorkRecord>> GetAllAsync()
        {
            return await dbContext.WorkRecords
                .Include(w => w.Employee) // Include để lấy HoTen
                .Include(w => w.DayType)
                .ToListAsync();
        }

        public async Task<WorkRecord?> GetByIdAsync(int maTinhCong)
        {
            return await dbContext.WorkRecords
                .Include(w => w.Employee) // Include để lấy HoTen
                .Include(w => w.DayType)
                .FirstOrDefaultAsync(w => w.MaTinhCong == maTinhCong);
        }

        public async Task<WorkRecord> AddAsync(WorkRecord entity)
        {
            await dbContext.WorkRecords.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<WorkRecord?> UpdateAsync(int maTinhCong, WorkRecord entity)
        {
            var existing = await dbContext.WorkRecords.FirstOrDefaultAsync(w => w.MaTinhCong == maTinhCong);
            if (existing is null) return null;

            existing.Ngay = entity.Ngay;
            existing.GioVao = entity.GioVao;
            existing.GioRa = entity.GioRa;
            existing.MaNhanVien = entity.MaNhanVien;
            existing.MaLoaiCong = entity.MaLoaiCong;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int maTinhCong)
        {
            var existing = await dbContext.WorkRecords.FirstOrDefaultAsync(w => w.MaTinhCong == maTinhCong);
            if (existing is null) return false;

            dbContext.WorkRecords.Remove(existing);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
