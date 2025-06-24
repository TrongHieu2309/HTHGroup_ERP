using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class SalaryRepository(AppDbContext dbContext) : ISalaryRepository
    {
        public async Task<IEnumerable<Salary>> GetSalariesAsync()
        {
            return await dbContext.Salaries
                .Include(s => s.Employee)
                .ToListAsync();
        }

        public async Task<Salary?> GetSalaryByIdAsync(int maLuong)
        {
            return await dbContext.Salaries
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(s => s.MaLuong == maLuong);
        }

        public async Task<Salary> AddSalaryAsync(Salary salary)
        {
            await dbContext.Salaries.AddAsync(salary);
            await dbContext.SaveChangesAsync();
            return salary;
        }

        public async Task<Salary?> UpdateSalaryAsync(int maLuong, Salary salary)
        {
            var existing = await dbContext.Salaries.FirstOrDefaultAsync(s => s.MaLuong == maLuong);
            if (existing is null) return null;

            existing.MaNV = salary.MaNV;
            existing.Thang = salary.Thang;
            existing.Nam = salary.Nam;
            existing.LuongCoBan = salary.LuongCoBan;
            existing.TongTC = salary.TongTC;
            existing.TongPC = salary.TongPC;
            // Thực lĩnh được tính tự động bằng HasComputedColumnSql

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteSalaryAsync(int maLuong)
        {
            var salary = await dbContext.Salaries.FirstOrDefaultAsync(s => s.MaLuong == maLuong);
            if (salary is null) return false;

            dbContext.Salaries.Remove(salary);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
