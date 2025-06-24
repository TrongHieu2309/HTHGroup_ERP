using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto?> RegisterAsync(UserRegisterDto dto);
        Task<UserDto?> LoginAsync(UserLoginDto dto);
        Task<UserDto?> UpdateAsync(int id, UserUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
