using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class ShiftTypeRepository(AppDbContext dbContext) : IShiftTypeRepository
    {
        public async Task<IEnumerable<ShiftType>> GetAllShiftTypesAsync()
        {
            return await dbContext.ShiftTypes.ToListAsync();
        }

        public async Task<ShiftType?> GetShiftTypeByIdAsync(int maLoaiCa)
        {
            return await dbContext.ShiftTypes.FirstOrDefaultAsync(s => s.MaLoaiCa == maLoaiCa);
        }

        public async Task<ShiftType> AddShiftTypeAsync(ShiftType entity)
        {
            await dbContext.ShiftTypes.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<ShiftType?> UpdateShiftTypeAsync(int maLoaiCa, ShiftType entity)
        {
            var existing = await dbContext.ShiftTypes.FirstOrDefaultAsync(s => s.MaLoaiCa == maLoaiCa);
            if (existing is null) return null;

            existing.CaLamViec = entity.CaLamViec;
            existing.HeSoTangCa = entity.HeSoTangCa;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteShiftTypeAsync(int maLoaiCa)
        {
            var entity = await dbContext.ShiftTypes.FirstOrDefaultAsync(s => s.MaLoaiCa == maLoaiCa);
            if (entity is null) return false;

            dbContext.ShiftTypes.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
