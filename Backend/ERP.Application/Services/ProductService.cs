using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class ProductService(IProductRepository repository) : IProductService
    {
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await repository.GetAllAsync();
            return products.Select(p => new ProductDto
            {
                MaSP = p.MaSP,
                TenSanPham = p.TenSanPham,
                MoTa = p.MoTa,
                MaNCC = p.MaNCC,
                MaMatHang = p.MaMatHang,
                DonGia = p.DonGia,
                SoLuongTon = p.SoLuongTon,
                NgayNhap = p.NgayNhap,
                TrangThai = p.TrangThai
            });
        }

        public async Task<ProductDto?> GetByIdAsync(int maSP)
        {
            var product = await repository.GetByIdAsync(maSP);
            if (product == null) return null;

            return new ProductDto
            {
                MaSP = product.MaSP,
                TenSanPham = product.TenSanPham,
                MoTa = product.MoTa,
                MaNCC = product.MaNCC,
                MaMatHang = product.MaMatHang,
                DonGia = product.DonGia,
                SoLuongTon = product.SoLuongTon,
                NgayNhap = product.NgayNhap,
                TrangThai = product.TrangThai
            };
        }

        public async Task<ProductDto> CreateAsync(ProductInputDto input)
        {
            var entity = new Product
            {
                TenSanPham = input.TenSanPham,
                MoTa = input.MoTa,
                MaNCC = input.MaNCC,
                MaMatHang = input.MaMatHang,
                DonGia = input.DonGia,
                SoLuongTon = input.SoLuongTon,
                NgayNhap = input.NgayNhap,
                TrangThai = input.TrangThai
            };

            var created = await repository.AddAsync(entity);

            return new ProductDto
            {
                MaSP = created.MaSP,
                TenSanPham = created.TenSanPham,
                MoTa = created.MoTa,
                MaNCC = created.MaNCC,
                MaMatHang = created.MaMatHang,
                DonGia = created.DonGia,
                SoLuongTon = created.SoLuongTon,
                NgayNhap = created.NgayNhap,
                TrangThai = created.TrangThai
            };
        }

        public async Task<ProductDto?> UpdateAsync(int maSP, ProductInputDto input)
        {
            var entity = new Product
            {
                TenSanPham = input.TenSanPham,
                MoTa = input.MoTa,
                MaNCC = input.MaNCC,
                MaMatHang = input.MaMatHang,
                DonGia = input.DonGia,
                SoLuongTon = input.SoLuongTon,
                NgayNhap = input.NgayNhap,
                TrangThai = input.TrangThai
            };

            var updated = await repository.UpdateAsync(maSP, entity);
            if (updated == null) return null;

            return new ProductDto
            {
                MaSP = updated.MaSP,
                TenSanPham = updated.TenSanPham,
                MoTa = updated.MoTa,
                MaNCC = updated.MaNCC,
                MaMatHang = updated.MaMatHang,
                DonGia = updated.DonGia,
                SoLuongTon = updated.SoLuongTon,
                NgayNhap = updated.NgayNhap,
                TrangThai = updated.TrangThai
            };
        }

        public async Task<bool> DeleteAsync(int maSP)
        {
            return await repository.DeleteAsync(maSP);
        }
    }
}
