using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class SectionRepository(AppDbContext dbContext) : ISectionRepository
    {
        // Lấy tất cả bộ phận
        public async Task<IEnumerable<Section>> GetAllSectionsAsync()
        {
            return await dbContext.Sections.ToListAsync();
        }

        // Lấy bộ phận theo Id
        public async Task<Section?> GetSectionByIdAsync(int id)
        {
            return await dbContext.Sections.FirstOrDefaultAsync(s => s.Id == id);
        }

        // Thêm bộ phận mới
        public async Task<Section> AddSectionAsync(Section entity)
        {
            await dbContext.Sections.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        // Cập nhật bộ phận
        public async Task<Section?> UpdateSectionAsync(int id, Section entity)
        {
            var existing = await dbContext.Sections.FirstOrDefaultAsync(s => s.Id == id);
            if (existing is null) return null;

            existing.MaBoPhan = entity.MaBoPhan;
            existing.TenBoPhan = entity.TenBoPhan;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        // Xoá bộ phận
        public async Task<bool> DeleteSectionAsync(int id)
        {
            var section = await dbContext.Sections.FirstOrDefaultAsync(s => s.Id == id);
            if (section is null) return false;

            dbContext.Sections.Remove(section);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
