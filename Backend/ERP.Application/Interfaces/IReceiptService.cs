using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IReceiptService
    {
        Task<IEnumerable<ReceiptDto>> GetAllAsync();
        Task<ReceiptDto?> GetByIdAsync(int maHD);
        Task<ReceiptDto> AddAsync(ReceiptInputDto inputDto);
        Task<ReceiptDto?> UpdateAsync(int maHD, ReceiptInputDto inputDto);
        Task<bool> DeleteAsync(int maHD);
    }
}
