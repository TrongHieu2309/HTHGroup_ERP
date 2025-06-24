using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IReceiptRepository
    {
        Task<IEnumerable<Receipt>> GetAllAsync();
        Task<Receipt?> GetByIdAsync(int maHD);
        Task<Receipt> AddAsync(Receipt entity);
        Task<Receipt?> UpdateAsync(int maHD, Receipt entity);
        Task<bool> DeleteAsync(int maHD);
    }
}
