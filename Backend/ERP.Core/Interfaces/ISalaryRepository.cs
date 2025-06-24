using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface ISalaryRepository
    {
        Task<IEnumerable<Salary>> GetSalariesAsync();
        Task<Salary?> GetSalaryByIdAsync(int maLuong);
        Task<Salary> AddSalaryAsync(Salary salary);
        Task<Salary?> UpdateSalaryAsync(int maLuong, Salary salary);
        Task<bool> DeleteSalaryAsync(int maLuong);
    }
}
