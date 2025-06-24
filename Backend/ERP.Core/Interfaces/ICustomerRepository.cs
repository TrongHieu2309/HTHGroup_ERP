using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task<Customer> AddAsync(Customer entity);
        Task<Customer?> UpdateAsync(int id, Customer entity);
        Task<bool> DeleteAsync(int id);
    }
}
