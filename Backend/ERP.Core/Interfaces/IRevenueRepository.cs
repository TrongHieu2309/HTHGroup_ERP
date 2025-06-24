using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IRevenueRepository
    {
        Task<IEnumerable<Revenue>> GetRevenues();
        Task<Revenue?> GetRevenueByIdAsync(int mathu);
        Task<Revenue> AddRevenueAsync(Revenue entity);
        Task<Revenue?> UpdateRevenueAsync(int mathu, Revenue entity);
        Task<bool> DeleteRevenueAsync(int mathu);
    }
}
