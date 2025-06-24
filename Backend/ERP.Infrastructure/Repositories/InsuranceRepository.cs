using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class InsuranceRepository(AppDbContext dbContext) : IInsuranceRepository
    {
        // Thêm Bảo hiểm mới
        public async Task<Insurance> AddInsuranceAsync(Insurance entity)
        {
            await dbContext.Insurances.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        // Lấy toàn bộ Bảo hiểm
        public async Task<IEnumerable<Insurance>> GetInsurancesAsync()
        {
            return await dbContext.Insurances
                .Include(i => i.Employee)
                .ToListAsync();
        }

        // Lấy Bảo hiểm theo mã
        public async Task<Insurance?> GetInsuranceByIdAsync(int mabh)
        {
            return await dbContext.Insurances
                .Include(i => i.Employee)
                .FirstOrDefaultAsync(i => i.MaBH == mabh);
        }

        // Cập nhật Bảo hiểm
        public async Task<Insurance?> UpdateInsuranceAsync(int mabh, Insurance entity)
        {
            var existing = await dbContext.Insurances.FirstOrDefaultAsync(i => i.MaBH == mabh);
            if (existing is null) return null;

            existing.MaNV = entity.MaNV;
            existing.LoaiBH = entity.LoaiBH;
            existing.SoBH = entity.SoBH;
            existing.BenhVien = entity.BenhVien;
            existing.NgayCap = entity.NgayCap;
            existing.NgayHetHan = entity.NgayHetHan;
            existing.TinhTrang = entity.TinhTrang;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        // Xoá Bảo hiểm
        public async Task<bool> DeleteInsuranceAsync(int mabh)
        {
            var insurance = await dbContext.Insurances.FirstOrDefaultAsync(i => i.MaBH == mabh);
            if (insurance is null) return false;

            dbContext.Insurances.Remove(insurance);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
