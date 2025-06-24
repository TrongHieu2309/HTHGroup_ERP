using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IJobTitleRepository
    {
        Task<IEnumerable<JobTitle>> GetAllAsync();
        Task<JobTitle?> GetByIdAsync(int maChucVu);
        Task<JobTitle> AddAsync(JobTitle entity);
        Task<JobTitle?> UpdateAsync(int maChucVu, JobTitle entity);
        Task<bool> DeleteAsync(int maChucVu);
    }
}
