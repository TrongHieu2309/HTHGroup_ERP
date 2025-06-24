using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class AuthoriseRepository(AppDbContext dbContext) : IAuthoriseRepository
    {
        public async Task<IEnumerable<Authorise>> GetAllAsync()
        {
            return await dbContext.Authorises
                .Include(a => a.Roles)
                .Include(a => a.Authorisation)
                .ToListAsync();
        }

        public async Task<Authorise?> GetByIdAsync(string maVaiTro, int maQuyen)
        {
            return await dbContext.Authorises
                .Include(a => a.Roles)
                .Include(a => a.Authorisation)
                .FirstOrDefaultAsync(a => a.MaVaiTro == maVaiTro && a.MaQuyen == maQuyen);
        }

        public async Task<Authorise> AddAsync(Authorise entity)
        {
            await dbContext.Authorises.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Authorise?> UpdateAsync(string maVaiTro, int maQuyen, Authorise entity)
        {
            var existing = await dbContext.Authorises
                .FirstOrDefaultAsync(a => a.MaVaiTro == maVaiTro && a.MaQuyen == maQuyen);

            if (existing is null) return null;

            existing.HanhDong = entity.HanhDong;
            existing.MaVaiTro = entity.MaVaiTro;
            existing.MaQuyen = entity.MaQuyen;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(string maVaiTro, int maQuyen)
        {
            var entity = await dbContext.Authorises
                .FirstOrDefaultAsync(a => a.MaVaiTro == maVaiTro && a.MaQuyen == maQuyen);

            if (entity is null) return false;

            dbContext.Authorises.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
