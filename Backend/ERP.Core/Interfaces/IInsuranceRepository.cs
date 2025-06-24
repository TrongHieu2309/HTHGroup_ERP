using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IInsuranceRepository
    {
        // Thêm Bảo hiểm mới
        Task<Insurance> AddInsuranceAsync(Insurance entity);

        // Lấy toàn bộ Bảo hiểm
        Task<IEnumerable<Insurance>> GetInsurancesAsync();

        // Lấy Bảo hiểm theo mã
        Task<Insurance?> GetInsuranceByIdAsync(int mabh);

        // Cập nhật Bảo hiểm
        Task<Insurance?> UpdateInsuranceAsync(int mabh, Insurance entity);

        // Xoá Bảo hiểm
        Task<bool> DeleteInsuranceAsync(int mabh);
    }
}
