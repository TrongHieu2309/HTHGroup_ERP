using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int maSP);
        Task<ProductDto> CreateAsync(ProductInputDto input);
        Task<ProductDto?> UpdateAsync(int maSP, ProductInputDto input);
        Task<bool> DeleteAsync(int maSP);
    }
}
