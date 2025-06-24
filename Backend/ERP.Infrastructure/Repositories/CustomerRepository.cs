using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class CustomerRepository(AppDbContext dbContext) : ICustomerRepository
    {
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await dbContext.Customers
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await dbContext.Customers
                .FirstOrDefaultAsync(c => c.MaKH == id);
        }

        public async Task<Customer> AddAsync(Customer entity)
        {
            await dbContext.Customers.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Customer?> UpdateAsync(int id, Customer entity)
        {
            var existing = await dbContext.Customers
                .FirstOrDefaultAsync(c => c.MaKH == id);

            if (existing is null) return null;

            existing.TenKhachHang = entity.TenKhachHang;
            existing.DiaChi = entity.DiaChi;
            existing.SoDienThoai = entity.SoDienThoai;
            existing.Email = entity.Email;
            existing.GhiChu = entity.GhiChu;
            existing.TichDiem = entity.TichDiem;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await dbContext.Customers
                .FirstOrDefaultAsync(c => c.MaKH == id);

            if (existing is null) return false;

            dbContext.Customers.Remove(existing);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
