using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class JobTitleService(IJobTitleRepository repository) : IJobTitleService
    {
        public async Task<IEnumerable<JobTitleDto>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            return entities.Select(jt => new JobTitleDto
            {
                MaChucVu = jt.MaChucVu,
                TenChucVu = jt.TenChucVu
            });
        }

        public async Task<JobTitleDto?> GetByIdAsync(int maChucVu)
        {
            var entity = await repository.GetByIdAsync(maChucVu);
            if (entity == null) return null;

            return new JobTitleDto
            {
                MaChucVu = entity.MaChucVu,
                TenChucVu = entity.TenChucVu
            };
        }

        public async Task<JobTitleDto> CreateAsync(JobTitleInputDto input)
        {
            var entity = new JobTitle
            {
                TenChucVu = input.TenChucVu
            };

            var created = await repository.AddAsync(entity);

            return new JobTitleDto
            {
                MaChucVu = created.MaChucVu,
                TenChucVu = created.TenChucVu
            };
        }

        public async Task<JobTitleDto?> UpdateAsync(int maChucVu, JobTitleInputDto input)
        {
            var entity = new JobTitle
            {
                TenChucVu = input.TenChucVu
            };

            var updated = await repository.UpdateAsync(maChucVu, entity);
            if (updated == null) return null;

            return new JobTitleDto
            {
                MaChucVu = updated.MaChucVu,
                TenChucVu = updated.TenChucVu
            };
        }

        public async Task<bool> DeleteAsync(int maChucVu)
        {
            return await repository.DeleteAsync(maChucVu);
        }
    }
}
