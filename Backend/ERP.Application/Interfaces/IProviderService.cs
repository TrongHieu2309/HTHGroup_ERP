using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IProviderService
    {
        Task<IEnumerable<ProviderDto>> GetAllProvidersAsync();
        Task<ProviderDto?> GetProviderByIdAsync(int id);
        Task<ProviderDto> AddProviderAsync(ProviderInputDto input);
        Task<ProviderDto?> UpdateProviderAsync(int id, ProviderInputDto input);
        Task<bool> DeleteProviderAsync(int id);
    }
}
