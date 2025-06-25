using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class SectionRepository(AppDbContext dbContext) : ISectionRepository
    {
        public async Task<IEnumerable<Section>> GetAllSectionsAsync()
        {
            return await dbContext.Sections
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Section?> GetSectionByIdAsync(int maBoPhan)
        {
            return await dbContext.Sections
                .FirstOrDefaultAsync(s => s.MaBoPhan == maBoPhan);
        }

        public async Task<Section> AddSectionAsync(Section entity)
        {
            await dbContext.Sections.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Section?> UpdateSectionAsync(int maBoPhan, Section entity)
        {
            var existing = await dbContext.Sections
                .FirstOrDefaultAsync(s => s.MaBoPhan == maBoPhan);

            if (existing is null) return null;

            existing.TenBoPhan = entity.TenBoPhan;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteSectionAsync(int maBoPhan)
        {
            var existing = await dbContext.Sections
                .FirstOrDefaultAsync(s => s.MaBoPhan == maBoPhan);

            if (existing is null) return false;

            dbContext.Sections.Remove(existing);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
