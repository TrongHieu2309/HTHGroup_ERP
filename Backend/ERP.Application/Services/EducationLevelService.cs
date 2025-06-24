using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class EducationLevelService(IEducationLevelRepository repository) : IEducationLevelService
    {
        public async Task<IEnumerable<EducationLevelDto>> GetAllAsync()
        {
            var list = await repository.GetAllAsync();
            return list.Select(e => new EducationLevelDto
            {
                MaTDHV = e.MaTDHV,
                TrinhDoHocVan = e.TrinhDoHocVan
            });
        }

        public async Task<EducationLevelDto?> GetByIdAsync(int id)
        {
            var entity = await repository.GetByIdAsync(id);
            if (entity is null) return null;

            return new EducationLevelDto
            {
                MaTDHV = entity.MaTDHV,
                TrinhDoHocVan = entity.TrinhDoHocVan
            };
        }

        public async Task<EducationLevelDto> AddAsync(EducationLevelInputDto dto)
        {
            var entity = new EducationLevel
            {
                TrinhDoHocVan = dto.TrinhDoHocVan
            };

            var added = await repository.AddAsync(entity);

            return new EducationLevelDto
            {
                MaTDHV = added.MaTDHV,
                TrinhDoHocVan = added.TrinhDoHocVan
            };
        }

        public async Task<EducationLevelDto?> UpdateAsync(int id, EducationLevelInputDto dto)
        {
            var update = new EducationLevel
            {
                TrinhDoHocVan = dto.TrinhDoHocVan
            };

            var result = await repository.UpdateAsync(id, update);
            if (result is null) return null;

            return new EducationLevelDto
            {
                MaTDHV = result.MaTDHV,
                TrinhDoHocVan = result.TrinhDoHocVan
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
