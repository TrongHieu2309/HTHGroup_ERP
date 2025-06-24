using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class AllowanceRepository(AppDbContext dbContext) : IAllowanceRepository
    {
        // Thêm Phụ cấp mới
        public async Task<Allowance> AddAllowanceAsync(Allowance entity)
        {
            await dbContext.Allowances.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        // GET ALL Allowances
        public async Task<IEnumerable<Allowance>> GetAllowances()
        {
            return await dbContext.Allowances.ToListAsync();
        }

        // GET Allowance by Id
        public async Task<Allowance?> GetAllowanceByIdAsync(int mapc)
        {
            return await dbContext.Allowances.FirstOrDefaultAsync(x => x.MaPC == mapc);
        }

        // UPDATE Phụ cấp
        public async Task<Allowance?> UpdateAllowanceAsync(int mapc, Allowance entity)
        {
            var existing = await dbContext.Allowances.FirstOrDefaultAsync(x => x.MaPC == mapc);
            if (existing is null) return null;

            existing.TenPhuCap = entity.TenPhuCap;
            existing.SoTien = entity.SoTien;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        // DELETE Phụ cấp
        public async Task<bool> DeleteAllowanceAsync(int mapc)
        {
            var allowance = await dbContext.Allowances.FirstOrDefaultAsync(x => x.MaPC == mapc);
            if (allowance is null) return false;

            dbContext.Allowances.Remove(allowance);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
