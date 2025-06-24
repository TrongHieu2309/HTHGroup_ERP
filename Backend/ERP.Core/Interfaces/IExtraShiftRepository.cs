using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IExtraShiftRepository
    {
        Task<IEnumerable<ExtraShift>> GetAllExtraShiftsAsync();
        Task<ExtraShift?> GetExtraShiftByIdAsync(int maTangCa);
        Task<ExtraShift> AddExtraShiftAsync(ExtraShift entity);
        Task<ExtraShift?> UpdateExtraShiftAsync(int maTangCa, ExtraShift entity);
        Task<bool> DeleteExtraShiftAsync(int maTangCa);
    }
}
