using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class SectionService(ISectionRepository repository) : ISectionService
    {
        public async Task<IEnumerable<SectionDto>> GetAllSectionsAsync()
        {
            var entities = await repository.GetAllSectionsAsync();
            return entities.Select(s => new SectionDto
            {
                Id = s.Id,
                MaBoPhan = s.MaBoPhan,
                TenBoPhan = s.TenBoPhan
            });
        }

        public async Task<SectionDto?> GetSectionByIdAsync(int id)
        {
            var section = await repository.GetSectionByIdAsync(id);
            if (section == null) return null;

            return new SectionDto
            {
                Id = section.Id,
                MaBoPhan = section.MaBoPhan,
                TenBoPhan = section.TenBoPhan
            };
        }

        public async Task<SectionDto> CreateSectionAsync(SectionInputDto input)
        {
            var entity = new Section
            {
                MaBoPhan = input.MaBoPhan,
                TenBoPhan = input.TenBoPhan
            };

            var created = await repository.AddSectionAsync(entity);

            return new SectionDto
            {
                Id = created.Id,
                MaBoPhan = created.MaBoPhan,
                TenBoPhan = created.TenBoPhan
            };
        }

        public async Task<SectionDto?> UpdateSectionAsync(int id, SectionInputDto input)
        {
            var entity = new Section
            {
                MaBoPhan = input.MaBoPhan,
                TenBoPhan = input.TenBoPhan
            };

            var updated = await repository.UpdateSectionAsync(id, entity);
            if (updated == null) return null;

            return new SectionDto
            {
                Id = updated.Id,
                MaBoPhan = updated.MaBoPhan,
                TenBoPhan = updated.TenBoPhan
            };
        }

        public async Task<bool> DeleteSectionAsync(int id)
        {
            return await repository.DeleteSectionAsync(id);
        }
    }
}
