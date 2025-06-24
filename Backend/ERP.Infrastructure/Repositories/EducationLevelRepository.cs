using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class EducationLevelRepository(AppDbContext dbContext) : IEducationLevelRepository
    {
        public async Task<IEnumerable<EducationLevel>> GetAllAsync()
        {
            return await dbContext.EducationLevels.ToListAsync();
        }

        public async Task<EducationLevel?> GetByIdAsync(int id)
        {
            return await dbContext.EducationLevels.FirstOrDefaultAsync(e => e.MaTDHV == id);
        }

        public async Task<EducationLevel> AddAsync(EducationLevel entity)
        {
            await dbContext.EducationLevels.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<EducationLevel?> UpdateAsync(int id, EducationLevel entity)
        {
            var existing = await dbContext.EducationLevels.FindAsync(id);
            if (existing is null) return null;

            existing.TrinhDoHocVan = entity.TrinhDoHocVan;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await dbContext.EducationLevels.FindAsync(id);
            if (entity is null) return false;

            dbContext.EducationLevels.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
