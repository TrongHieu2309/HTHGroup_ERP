using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class AllowanceService(IAllowanceRepository repository) : IAllowanceService
    {
        public async Task<IEnumerable<AllowanceDto>> GetAllAllowancesAsync()
        {
            var entities = await repository.GetAllowances();
            return entities.Select(x => new AllowanceDto
            {
                MaPC = x.MaPC,
                TenPhuCap = x.TenPhuCap,
                SoTien = x.SoTien
            });
        }

        public async Task<AllowanceDto?> GetAllowanceByIdAsync(int id)
        {
            var entity = await repository.GetAllowanceByIdAsync(id);
            if (entity == null) return null;

            return new AllowanceDto
            {
                MaPC = entity.MaPC,
                TenPhuCap = entity.TenPhuCap,
                SoTien = entity.SoTien
            };
        }

        public async Task<AllowanceDto> CreateAllowanceAsync(AllowanceInputDto input)
        {
            var entity = new Allowance
            {
                TenPhuCap = input.TenPhuCap,
                SoTien = input.SoTien
            };

            var created = await repository.AddAllowanceAsync(entity);

            return new AllowanceDto
            {
                MaPC = created.MaPC,
                TenPhuCap = created.TenPhuCap,
                SoTien = created.SoTien
            };
        }

        public async Task<AllowanceDto?> UpdateAllowanceAsync(int id, AllowanceInputDto input)
        {
            var entity = new Allowance
            {
                TenPhuCap = input.TenPhuCap,
                SoTien = input.SoTien
            };

            var updated = await repository.UpdateAllowanceAsync(id, entity);
            if (updated.MaPC != id) return null;

            return new AllowanceDto
            {
                MaPC = updated.MaPC,
                TenPhuCap = updated.TenPhuCap,
                SoTien = updated.SoTien
            };
        }

        public async Task<bool> DeleteAllowanceAsync(int id)
        {
            return await repository.DeleteAllowanceAsync(id);
        }
    }
}
