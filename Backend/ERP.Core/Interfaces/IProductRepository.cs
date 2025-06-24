using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int maSP);
        Task<Product> AddAsync(Product entity);
        Task<Product?> UpdateAsync(int maSP, Product entity);
        Task<bool> DeleteAsync(int maSP);
    }
}
