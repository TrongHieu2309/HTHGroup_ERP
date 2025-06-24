using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class EmployeeRepository(AppDbContext dbContext) : IEmployeeRepository
    {
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await dbContext.Employees
                .Include(e => e.Department)
                .Include(e => e.Section)
                .Include(e => e.JobTitle)
                .Include(e => e.EducationLevel)
                .ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int maNV)
        {
            return await dbContext.Employees
                .Include(e => e.Department)
                .Include(e => e.Section)
                .Include(e => e.JobTitle)
                .Include(e => e.EducationLevel)
                .FirstOrDefaultAsync(e => e.MaNV == maNV);
        }

        public async Task<Employee> AddAsync(Employee entity)
        {
            await dbContext.Employees.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee?> UpdateAsync(int maNV, Employee entity)
        {
            var existing = await dbContext.Employees.FindAsync(maNV);
            if (existing is null) return null;

            existing.HoTen = entity.HoTen;
            existing.NgaySinh = entity.NgaySinh;
            existing.GioiTinh = entity.GioiTinh;
            existing.SoDienThoai = entity.SoDienThoai;
            existing.CCCD = entity.CCCD;
            existing.Email = entity.Email;
            existing.DiaChi = entity.DiaChi;
            existing.MaPhongBan = entity.MaPhongBan;
            existing.MaBoPhan = entity.MaBoPhan;
            existing.MaChucVu = entity.MaChucVu;
            existing.MaTDHV = entity.MaTDHV;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int maNV)
        {
            var entity = await dbContext.Employees.FindAsync(maNV);
            if (entity is null) return false;

            dbContext.Employees.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
