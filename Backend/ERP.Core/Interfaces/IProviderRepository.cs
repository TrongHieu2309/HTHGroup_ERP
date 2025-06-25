using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IProviderRepository
    {
        // Thêm Nhà cung cấp mới
        Task<ProviderEntity> AddProviderAsync(ProviderEntity entity);

        // Get ALL Providers
        Task<IEnumerable<ProviderEntity>> GetProviders();

        // Get Provider by Id
        Task<ProviderEntity?> GetProviderByIdAsync(int id);

        // Update Nhà cung cấp
        Task<ProviderEntity?> UpdateProviderAsync(int id, ProviderEntity entity);

        // Xoá Nhà cung cấp
        Task<bool> DeleteProviderAsync(int id);
    }
}
