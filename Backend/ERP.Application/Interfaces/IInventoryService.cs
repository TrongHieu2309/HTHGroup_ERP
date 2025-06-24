using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryDto>> GetAllInventoriesAsync();
        Task<InventoryDto?> GetInventoryByIdAsync(int id);
        Task<InventoryDto> CreateInventoryAsync(InventoryInputDto input);
        Task<InventoryDto?> UpdateInventoryAsync(int id, InventoryInputDto input);
        Task<bool> DeleteInventoryAsync(int id);
    }
}
