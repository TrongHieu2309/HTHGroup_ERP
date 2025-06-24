using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class ShiftTypeService(IShiftTypeRepository repository) : IShiftTypeService
    {
        public async Task<IEnumerable<ShiftTypeDto>> GetAllAsync()
        {
            var data = await repository.GetAllShiftTypesAsync();
            return data.Select(x => new ShiftTypeDto
            {
                MaLoaiCa = x.MaLoaiCa,
                CaLamViec = x.CaLamViec,
                HeSoTangCa = x.HeSoTangCa
            });
        }

        public async Task<ShiftTypeDto?> GetByIdAsync(int id)
        {
            var entity = await repository.GetShiftTypeByIdAsync(id);
            if (entity is null) return null;

            return new ShiftTypeDto
            {
                MaLoaiCa = entity.MaLoaiCa,
                CaLamViec = entity.CaLamViec,
                HeSoTangCa = entity.HeSoTangCa
            };
        }

        public async Task<ShiftTypeDto> CreateAsync(ShiftTypeInputDto input)
        {
            var entity = new ShiftType
            {
                CaLamViec = input.CaLamViec,
                HeSoTangCa = input.HeSoTangCa
            };

            var created = await repository.AddShiftTypeAsync(entity);

            return new ShiftTypeDto
            {
                MaLoaiCa = created.MaLoaiCa,
                CaLamViec = created.CaLamViec,
                HeSoTangCa = created.HeSoTangCa
            };
        }

        public async Task<ShiftTypeDto?> UpdateAsync(int id, ShiftTypeInputDto input)
        {
            var updated = await repository.UpdateShiftTypeAsync(id, new ShiftType
            {
                CaLamViec = input.CaLamViec,
                HeSoTangCa = input.HeSoTangCa
            });

            if (updated is null) return null;

            return new ShiftTypeDto
            {
                MaLoaiCa = updated.MaLoaiCa,
                CaLamViec = updated.CaLamViec,
                HeSoTangCa = updated.HeSoTangCa
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteShiftTypeAsync(id);
        }
    }
}
