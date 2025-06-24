using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IInsuranceService
    {
        Task<IEnumerable<InsuranceDto>> GetAllInsurancesAsync();
        Task<InsuranceDto?> GetInsuranceByIdAsync(int id);
        Task<InsuranceDto> CreateInsuranceAsync(InsuranceInputDto input);
        Task<InsuranceDto?> UpdateInsuranceAsync(int id, InsuranceInputDto input);
        Task<bool> DeleteInsuranceAsync(int id);
    }
}
