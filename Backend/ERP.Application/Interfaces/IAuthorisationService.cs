using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IAuthorisationService
    {
        Task<IEnumerable<AuthorisationDto>> GetAllAsync();
        Task<AuthorisationDto?> GetByIdAsync(int id);
        Task<AuthorisationDto> CreateAsync(AuthorisationInputDto input);
        Task<AuthorisationDto?> UpdateAsync(int id, AuthorisationInputDto input);
        Task<bool> DeleteAsync(int id);
    }
}
