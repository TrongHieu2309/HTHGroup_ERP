using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IJobTitleService
    {
        Task<IEnumerable<JobTitleDto>> GetAllAsync();
        Task<JobTitleDto?> GetByIdAsync(int maChucVu);
        Task<JobTitleDto> CreateAsync(JobTitleInputDto input);
        Task<JobTitleDto?> UpdateAsync(int maChucVu, JobTitleInputDto input);
        Task<bool> DeleteAsync(int maChucVu);
    }
}
