using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class RolesRepository(AppDbContext dbContext) : IRolesRepository
    {
        // GET ALL roles
        public async Task<IEnumerable<Roles>> GetRolesAsync()
        {
            return await dbContext.Roles.ToListAsync();
        }

        // GET role by ID
        public async Task<Roles?> GetRoleByIdAsync(string maVaiTro)
        {
            return await dbContext.Roles.FirstOrDefaultAsync(r => r.MaVaiTro == maVaiTro);
        }

        // ADD new role
        public async Task<Roles> AddRoleAsync(Roles entity)
        {
            await dbContext.Roles.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        // UPDATE role
        public async Task<Roles?> UpdateRoleAsync(string maVaiTro, Roles entity)
        {
            var existing = await dbContext.Roles.FirstOrDefaultAsync(r => r.MaVaiTro == maVaiTro);
            if (existing is null) return null;

            existing.TenVaiTro = entity.TenVaiTro;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        // DELETE role
        public async Task<bool> DeleteRoleAsync(string maVaiTro)
        {
            var role = await dbContext.Roles.FirstOrDefaultAsync(r => r.MaVaiTro == maVaiTro);
            if (role is null) return false;

            dbContext.Roles.Remove(role);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
