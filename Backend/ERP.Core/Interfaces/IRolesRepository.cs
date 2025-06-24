using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IRolesRepository
    {
        Task<IEnumerable<Roles>> GetRolesAsync();
        Task<Roles?> GetRoleByIdAsync(string maVaiTro);
        Task<Roles> AddRoleAsync(Roles entity);
        Task<Roles?> UpdateRoleAsync(string maVaiTro, Roles entity);
        Task<bool> DeleteRoleAsync(string maVaiTro);
    }
}
