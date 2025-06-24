using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IRevenueService
    {
        Task<IEnumerable<RevenueDto>> GetAllRevenuesAsync();
        Task<RevenueDto?> GetRevenueByIdAsync(int id);
        Task<RevenueDto> CreateRevenueAsync(RevenueInputDto input);
        Task<RevenueDto?> UpdateRevenueAsync(int id, RevenueInputDto input);
        Task<bool> DeleteRevenueAsync(int id);
    }
}
