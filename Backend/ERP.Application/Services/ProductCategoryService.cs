using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class ProductCategoryService(IProductCategoryRepository repository) : IProductCategoryService
    {
        public async Task<IEnumerable<ProductCategoryDto>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            return entities.Select(pc => new ProductCategoryDto
            {
                MaMatHang = pc.MaMatHang,
                TenMatHang = pc.TenMatHang,
                SoLuong = pc.SoLuong,
                TongChiPhi = pc.TongChiPhi
            });
        }

        public async Task<ProductCategoryDto?> GetByIdAsync(int maMatHang)
        {
            var entity = await repository.GetByIdAsync(maMatHang);
            if (entity == null) return null;

            return new ProductCategoryDto
            {
                MaMatHang = entity.MaMatHang,
                TenMatHang = entity.TenMatHang,
                SoLuong = entity.SoLuong,
                TongChiPhi = entity.TongChiPhi
            };
        }

        public async Task<ProductCategoryDto> CreateAsync(ProductCategoryInputDto input)
        {
            var entity = new ProductCategory
            {
                TenMatHang = input.TenMatHang,
                SoLuong = input.SoLuong,
                TongChiPhi = input.TongChiPhi
            };

            var created = await repository.AddAsync(entity);

            return new ProductCategoryDto
            {
                MaMatHang = created.MaMatHang,
                TenMatHang = created.TenMatHang,
                SoLuong = created.SoLuong,
                TongChiPhi = created.TongChiPhi
            };
        }

        public async Task<ProductCategoryDto?> UpdateAsync(int maMatHang, ProductCategoryInputDto input)
        {
            var updated = await repository.UpdateAsync(maMatHang, new ProductCategory
            {
                TenMatHang = input.TenMatHang,
                SoLuong = input.SoLuong,
                TongChiPhi = input.TongChiPhi
            });

            if (updated == null) return null;

            return new ProductCategoryDto
            {
                MaMatHang = updated.MaMatHang,
                TenMatHang = updated.TenMatHang,
                SoLuong = updated.SoLuong,
                TongChiPhi = updated.TongChiPhi
            };
        }

        public async Task<bool> DeleteAsync(int maMatHang)
        {
            return await repository.DeleteAsync(maMatHang);
        }
    }
}
