using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategoryDto>> GetAllAsync();
        Task<ProductCategoryDto?> GetByIdAsync(int maMatHang);
        Task<ProductCategoryDto> CreateAsync(ProductCategoryInputDto input);
        Task<ProductCategoryDto?> UpdateAsync(int maMatHang, ProductCategoryInputDto input);
        Task<bool> DeleteAsync(int maMatHang);
    }
}
