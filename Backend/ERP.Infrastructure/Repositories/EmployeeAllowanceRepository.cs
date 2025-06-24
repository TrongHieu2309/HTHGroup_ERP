using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class EmployeeAllowanceRepository(AppDbContext dbContext) : IEmployeeAllowanceRepository
    {
        public async Task<IEnumerable<EmployeeAllowance>> GetAllAsync()
        {
            return await dbContext.EmployeeAllowances
                .Include(ea => ea.Employee)
                .Include(ea => ea.Allowance)
                .ToListAsync();
        }

        public async Task<EmployeeAllowance?> GetByIdAsync(int id)
        {
            return await dbContext.EmployeeAllowances
                .Include(ea => ea.Employee)
                .Include(ea => ea.Allowance)
                .FirstOrDefaultAsync(ea => ea.MaPhuCapNV == id);
        }

        public async Task<EmployeeAllowance> AddAsync(EmployeeAllowance entity)
        {
            await dbContext.EmployeeAllowances.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<EmployeeAllowance?> UpdateAsync(int id, EmployeeAllowance entity)
        {
            var existing = await dbContext.EmployeeAllowances
                .FirstOrDefaultAsync(ea => ea.MaPhuCapNV == id);

            if (existing is null) return null;

            existing.MaNV = entity.MaNV;
            existing.MaPC = entity.MaPC;
            existing.Thang = entity.Thang;
            existing.Nam = entity.Nam;
            existing.SoTien = entity.SoTien;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await dbContext.EmployeeAllowances
                .FirstOrDefaultAsync(ea => ea.MaPhuCapNV == id);

            if (entity is null) return false;

            dbContext.EmployeeAllowances.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
