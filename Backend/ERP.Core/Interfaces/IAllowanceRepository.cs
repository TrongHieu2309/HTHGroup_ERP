using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IAllowanceRepository
    {
        // Thêm Phụ cấp mới
        Task<Allowance> AddAllowanceAsync(Allowance entity);
        // Get ALL Allowances
        Task<IEnumerable<Allowance>> GetAllowances();
        // Get Allowance by Id
        Task<Allowance?> GetAllowanceByIdAsync(int mapc);
        // Update Phụ cấp
        Task<Allowance?> UpdateAllowanceAsync(int mapc, Allowance entity);
        // Xoá Phụ cấp
        Task<bool> DeleteAllowanceAsync(int mapc);
    }
}
// tối thêm controller, dto, service để test entity này trước khi làm các entity khác