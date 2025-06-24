using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetAllInventoriesAsync();
        Task<Inventory?> GetInventoryByIdAsync(int id);
        Task<Inventory> AddInventoryAsync(Inventory inventory);
        Task<Inventory?> UpdateInventoryAsync(int id, Inventory inventory);
        Task<bool> DeleteInventoryAsync(int id);
    }
}
