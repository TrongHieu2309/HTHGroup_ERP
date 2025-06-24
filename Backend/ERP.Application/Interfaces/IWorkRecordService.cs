using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IWorkRecordService
    {
        Task<IEnumerable<WorkRecordDto>> GetAllAsync();
        Task<WorkRecordDto?> GetByIdAsync(int id);
        Task<WorkRecordDto> CreateAsync(WorkRecordInputDto input);
        Task<WorkRecordDto?> UpdateAsync(int id, WorkRecordInputDto input);
        Task<bool> DeleteAsync(int id);
    }
}
