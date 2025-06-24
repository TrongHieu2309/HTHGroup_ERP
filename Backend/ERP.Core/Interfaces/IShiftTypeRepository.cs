using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IShiftTypeRepository
    {
        Task<IEnumerable<ShiftType>> GetAllShiftTypesAsync();
        Task<ShiftType?> GetShiftTypeByIdAsync(int maLoaiCa);
        Task<ShiftType> AddShiftTypeAsync(ShiftType entity);
        Task<ShiftType?> UpdateShiftTypeAsync(int maLoaiCa, ShiftType entity);
        Task<bool> DeleteShiftTypeAsync(int maLoaiCa);
    }
}
