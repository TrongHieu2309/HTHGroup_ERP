using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetAllAsync();
        Task<ProductCategory?> GetByIdAsync(int maMatHang);
        Task<ProductCategory> AddAsync(ProductCategory entity);
        Task<ProductCategory?> UpdateAsync(int maMatHang, ProductCategory entity);
        Task<bool> DeleteAsync(int maMatHang);
    }
}
