using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class DepartmentRepository(AppDbContext dbContext) : IDepartmentRepository
    {
        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await dbContext.Departments
                .Include(d => d.Employees)
                .ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await dbContext.Departments
                .Include(d => d.Employees)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Department> AddAsync(Department entity)
        {
            await dbContext.Departments.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Department?> UpdateAsync(int id, Department entity)
        {
            var existing = await dbContext.Departments.FindAsync(id);
            if (existing is null) return null;

            existing.MaPhongBan = entity.MaPhongBan;
            existing.TenPhongBan = entity.TenPhongBan;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await dbContext.Departments.FindAsync(id);
            if (entity is null) return false;

            dbContext.Departments.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
