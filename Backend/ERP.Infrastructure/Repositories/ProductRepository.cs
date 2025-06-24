using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext dbContext) : IProductRepository
    {
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await dbContext.Products
                .Include(p => p.Provider)
                .Include(p => p.ProductCategory)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int maSP)
        {
            return await dbContext.Products
                .Include(p => p.Provider)
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(p => p.MaSP == maSP);
        }

        public async Task<Product> AddAsync(Product entity)
        {
            await dbContext.Products.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Product?> UpdateAsync(int maSP, Product entity)
        {
            var existing = await dbContext.Products.FindAsync(maSP);
            if (existing == null) return null;

            existing.TenSanPham = entity.TenSanPham;
            existing.MoTa = entity.MoTa;
            existing.MaNCC = entity.MaNCC;
            existing.MaMatHang = entity.MaMatHang;
            existing.DonGia = entity.DonGia;
            existing.SoLuongTon = entity.SoLuongTon;
            existing.NgayNhap = entity.NgayNhap;
            existing.TrangThai = entity.TrangThai;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int maSP)
        {
            var entity = await dbContext.Products.FindAsync(maSP);
            if (entity == null) return false;

            dbContext.Products.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
