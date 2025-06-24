using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IReceiptDetailService
    {
        Task<IEnumerable<ReceiptDetailDto>> GetAllAsync();
        Task<ReceiptDetailDto?> GetByIdAsync(int id);
        Task<ReceiptDetailDto> CreateAsync(ReceiptDetailInputDto input);
        Task<ReceiptDetailDto?> UpdateAsync(int id, ReceiptDetailInputDto input);
        Task<bool> DeleteAsync(int id);
    }
}
