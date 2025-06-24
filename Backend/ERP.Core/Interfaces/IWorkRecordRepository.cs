using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IWorkRecordRepository
    {
        Task<IEnumerable<WorkRecord>> GetAllAsync();
        Task<WorkRecord?> GetByIdAsync(int maTinhCong);
        Task<WorkRecord> AddAsync(WorkRecord entity);
        Task<WorkRecord?> UpdateAsync(int maTinhCong, WorkRecord entity);
        Task<bool> DeleteAsync(int maTinhCong);
    }
}
