using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class RolesService(IRolesRepository repository) : IRolesService
    {
        public async Task<IEnumerable<RolesDto>> GetAllRolesAsync()
        {
            var roles = await repository.GetRolesAsync();
            return roles.Select(r => new RolesDto
            {
                MaVaiTro = r.MaVaiTro,
                TenVaiTro = r.TenVaiTro
            });
        }

        public async Task<RolesDto?> GetRoleByIdAsync(string maVaiTro)
        {
            var role = await repository.GetRoleByIdAsync(maVaiTro);
            if (role is null) return null;

            return new RolesDto
            {
                MaVaiTro = role.MaVaiTro,
                TenVaiTro = role.TenVaiTro
            };
        }

        public async Task<RolesDto> CreateRoleAsync(RolesInputDto input)
        {
            var role = new Roles
            {
                MaVaiTro = input.MaVaiTro,
                TenVaiTro = input.TenVaiTro
            };

            var created = await repository.AddRoleAsync(role);

            return new RolesDto
            {
                MaVaiTro = created.MaVaiTro,
                TenVaiTro = created.TenVaiTro
            };
        }

        public async Task<RolesDto?> UpdateRoleAsync(string maVaiTro, RolesInputDto input)
        {
            var role = new Roles
            {
                MaVaiTro = input.MaVaiTro, // optional: ensure immutability if necessary
                TenVaiTro = input.TenVaiTro
            };

            var updated = await repository.UpdateRoleAsync(maVaiTro, role);
            if (updated is null) return null;

            return new RolesDto
            {
                MaVaiTro = updated.MaVaiTro,
                TenVaiTro = updated.TenVaiTro
            };
        }

        public async Task<bool> DeleteRoleAsync(string maVaiTro)
        {
            return await repository.DeleteRoleAsync(maVaiTro);
        }
    }
}
