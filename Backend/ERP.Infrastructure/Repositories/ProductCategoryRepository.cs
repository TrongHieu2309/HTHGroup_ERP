using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class ProductCategoryRepository(AppDbContext dbContext) : IProductCategoryRepository
    {
        public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            return await dbContext.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory?> GetByIdAsync(int maMatHang)
        {
            return await dbContext.ProductCategories.FindAsync(maMatHang);
        }

        public async Task<ProductCategory> AddAsync(ProductCategory entity)
        {
            await dbContext.ProductCategories.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<ProductCategory?> UpdateAsync(int maMatHang, ProductCategory entity)
        {
            var existing = await dbContext.ProductCategories.FindAsync(maMatHang);
            if (existing is null) return null;

            existing.TenMatHang = entity.TenMatHang;
            existing.SoLuong = entity.SoLuong;
            existing.TongChiPhi = entity.TongChiPhi;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int maMatHang)
        {
            var entity = await dbContext.ProductCategories.FindAsync(maMatHang);
            if (entity is null) return false;

            dbContext.ProductCategories.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
