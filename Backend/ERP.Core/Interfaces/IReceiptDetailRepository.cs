using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IReceiptDetailRepository
    {
        Task<IEnumerable<ReceiptDetail>> GetAllAsync();
        Task<ReceiptDetail?> GetByIdAsync(int id);
        Task<ReceiptDetail> AddAsync(ReceiptDetail entity);
        Task<ReceiptDetail?> UpdateAsync(int id, ReceiptDetail entity);
        Task<bool> DeleteAsync(int id);
    }
}
