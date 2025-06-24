using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IDayTypeRepository
    {
        Task<IEnumerable<DayType>> GetAllAsync();
        Task<DayType?> GetByIdAsync(int maLoaiCong);
        Task<DayType> AddAsync(DayType entity);
        Task<DayType?> UpdateAsync(int maLoaiCong, DayType entity);
        Task<bool> DeleteAsync(int maLoaiCong);
    }
}
