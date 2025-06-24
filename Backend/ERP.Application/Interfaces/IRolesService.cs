using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IRolesService
    {
        Task<IEnumerable<RolesDto>> GetAllRolesAsync();
        Task<RolesDto?> GetRoleByIdAsync(string maVaiTro);
        Task<RolesDto> CreateRoleAsync(RolesInputDto input);
        Task<RolesDto?> UpdateRoleAsync(string maVaiTro, RolesInputDto input);
        Task<bool> DeleteRoleAsync(string maVaiTro);
    }
}
