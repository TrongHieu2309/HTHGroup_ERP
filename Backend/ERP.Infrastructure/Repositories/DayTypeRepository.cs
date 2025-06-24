using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class DayTypeRepository(AppDbContext dbContext) : IDayTypeRepository 
    {
        public async Task<IEnumerable<DayType>> GetAllAsync()
        {
            return await dbContext.DayTypes.ToListAsync();
        }

        public async Task<DayType?> GetByIdAsync(int maLoaiCong)
        {
            return await dbContext.DayTypes.FindAsync(maLoaiCong);
        }

        public async Task<DayType> AddAsync(DayType entity)
        {
            await dbContext.DayTypes.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<DayType?> UpdateAsync(int maLoaiCong, DayType entity)
        {
            var existing = await dbContext.DayTypes.FindAsync(maLoaiCong);
            if (existing is null) return null;

            existing.TenLoaiCong = entity.TenLoaiCong;
            existing.HeSo = entity.HeSo;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int maLoaiCong)
        {
            var entity = await dbContext.DayTypes.FindAsync(maLoaiCong);
            if (entity is null) return false;

            dbContext.DayTypes.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
