using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IAvailableStockRepository
    {
        Task<IEnumerable<AvailableStock>> GetAllAsync();
        Task<AvailableStock?> GetByIdAsync(int id);
        Task<AvailableStock> AddAsync(AvailableStock stock);
        Task<AvailableStock?> UpdateAsync(int id, AvailableStock stock);
        Task<bool> DeleteAsync(int id);
    }
}
