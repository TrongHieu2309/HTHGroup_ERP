using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class JobTitleRepository(AppDbContext dbContext) : IJobTitleRepository
    {
        public async Task<IEnumerable<JobTitle>> GetAllAsync()
        {
            return await dbContext.JobTitles.ToListAsync();
        }

        public async Task<JobTitle?> GetByIdAsync(int maChucVu)
        {
            return await dbContext.JobTitles.FindAsync(maChucVu);
        }

        public async Task<JobTitle> AddAsync(JobTitle entity)
        {
            await dbContext.JobTitles.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<JobTitle?> UpdateAsync(int maChucVu, JobTitle entity)
        {
            var existing = await dbContext.JobTitles.FindAsync(maChucVu);
            if (existing is null) return null;

            existing.TenChucVu = entity.TenChucVu;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int maChucVu)
        {
            var entity = await dbContext.JobTitles.FindAsync(maChucVu);
            if (entity is null) return false;

            dbContext.JobTitles.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
