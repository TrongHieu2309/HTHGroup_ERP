using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto?> GetByIdAsync(int id);
        Task<CustomerDto> CreateAsync(CustomerInputDto input);
        Task<CustomerDto?> UpdateAsync(int id, CustomerInputDto input);
        Task<bool> DeleteAsync(int id);
    }
}
