using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class AuthorisationRepository(AppDbContext dbContext) : IAuthorisationRepository
    {
        public async Task<IEnumerable<Authorisation>> GetAllAsync()
        {
            return await dbContext.Authorisations
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Authorisation?> GetByIdAsync(int id)
        {
            return await dbContext.Authorisations
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.MaQuyen == id);
        }

        public async Task<Authorisation> AddAsync(Authorisation entity)
        {
            await dbContext.Authorisations.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Authorisation?> UpdateAsync(int id, Authorisation entity)
        {
            var existing = await dbContext.Authorisations.FirstOrDefaultAsync(x => x.MaQuyen == id);
            if (existing == null) return null;

            existing.TenQuyen = entity.TenQuyen;
            await dbContext.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await dbContext.Authorisations.FirstOrDefaultAsync(x => x.MaQuyen == id);
            if (entity == null) return false;

            dbContext.Authorisations.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
