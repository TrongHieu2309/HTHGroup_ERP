using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class ExtraShiftRepository(AppDbContext dbContext) : IExtraShiftRepository
    {
        // Lấy tất cả tăng ca
        public async Task<IEnumerable<ExtraShift>> GetAllExtraShiftsAsync()
        {
            return await dbContext.ExtraShifts
                .Include(e => e.Employee)
                .Include(e => e.ShiftType)
                .ToListAsync();
        }

        // Lấy tăng ca theo mã
        public async Task<ExtraShift?> GetExtraShiftByIdAsync(int maTangCa)
        {
            return await dbContext.ExtraShifts
                .Include(e => e.Employee)
                .Include(e => e.ShiftType)
                .FirstOrDefaultAsync(e => e.MaTangCa == maTangCa);
        }

        // Thêm mới
        public async Task<ExtraShift> AddExtraShiftAsync(ExtraShift entity)
        {
            await dbContext.ExtraShifts.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        // Cập nhật
        public async Task<ExtraShift?> UpdateExtraShiftAsync(int maTangCa, ExtraShift entity)
        {
            var existing = await dbContext.ExtraShifts
                .FirstOrDefaultAsync(e => e.MaTangCa == maTangCa);

            if (existing is null) return null;

            existing.Ngay = entity.Ngay;
            existing.SoGio = entity.SoGio;
            existing.MaNV = entity.MaNV;
            existing.MaLoaiCa = entity.MaLoaiCa;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        // Xoá
        public async Task<bool> DeleteExtraShiftAsync(int maTangCa)
        {
            var existing = await dbContext.ExtraShifts
                .FirstOrDefaultAsync(e => e.MaTangCa == maTangCa);

            if (existing is null) return false;

            dbContext.ExtraShifts.Remove(existing);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
