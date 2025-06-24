using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IAuthoriseService
    {
        Task<IEnumerable<AuthoriseDto>> GetAllAsync();
        Task<AuthoriseDto?> GetByIdAsync(string maVaiTro, int maQuyen);
        Task<AuthoriseDto> CreateAsync(AuthoriseInputDto input);
        Task<AuthoriseDto?> UpdateAsync(string maVaiTro, int maQuyen, AuthoriseInputDto input);
        Task<bool> DeleteAsync(string maVaiTro, int maQuyen);
    }
}
