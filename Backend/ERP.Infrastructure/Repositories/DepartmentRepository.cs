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
            return await dbContext.Departments.ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int maPhongBan)
        {
            return await dbContext.Departments.FindAsync(maPhongBan);
        }

        public async Task<Department> AddAsync(Department entity)
        {
            await dbContext.Departments.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Department?> UpdateAsync(int maPhongBan, Department entity)
        {
            var existing = await dbContext.Departments.FindAsync(maPhongBan);
            if (existing is null) return null;

            existing.TenPhongBan = entity.TenPhongBan;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int maPhongBan)
        {
            var entity = await dbContext.Departments.FindAsync(maPhongBan);
            if (entity is null) return false;

            dbContext.Departments.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
