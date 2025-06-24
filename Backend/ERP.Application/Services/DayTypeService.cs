using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class DayTypeService(IDayTypeRepository repository) : IDayTypeService
    {
        public async Task<IEnumerable<DayTypeDto>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            return entities.Select(e => new DayTypeDto
            {
                MaLoaiCong = e.MaLoaiCong,
                TenLoaiCong = e.TenLoaiCong,
                HeSo = e.HeSo
            });
        }

        public async Task<DayTypeDto?> GetByIdAsync(int id)
        {
            var entity = await repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new DayTypeDto
            {
                MaLoaiCong = entity.MaLoaiCong,
                TenLoaiCong = entity.TenLoaiCong,
                HeSo = entity.HeSo
            };
        }

        public async Task<DayTypeDto> CreateAsync(DayTypeInputDto inputDto)
        {
            var entity = new DayType
            {
                TenLoaiCong = inputDto.TenLoaiCong,
                HeSo = inputDto.HeSo
            };

            var result = await repository.AddAsync(entity);

            return new DayTypeDto
            {
                MaLoaiCong = result.MaLoaiCong,
                TenLoaiCong = result.TenLoaiCong,
                HeSo = result.HeSo
            };
        }

        public async Task<DayTypeDto?> UpdateAsync(int id, DayTypeInputDto inputDto)
        {
            var entity = new DayType
            {
                TenLoaiCong = inputDto.TenLoaiCong,
                HeSo = inputDto.HeSo
            };

            var updated = await repository.UpdateAsync(id, entity);
            if (updated == null) return null;

            return new DayTypeDto
            {
                MaLoaiCong = updated.MaLoaiCong,
                TenLoaiCong = updated.TenLoaiCong,
                HeSo = updated.HeSo
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
