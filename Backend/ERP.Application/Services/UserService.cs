using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class UserService(IUserRepository repository) : IUserService
    {
        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await repository.GetAllAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                TenDangNhap = u.TenDangNhap,
                MatKhau = u.MatKhau,
                MaVaiTro = u.MaVaiTro
            });
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await repository.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                TenDangNhap = user.TenDangNhap,
                MatKhau = user.MatKhau,
                MaVaiTro = user.MaVaiTro
            };
        }

        public async Task<UserDto?> RegisterAsync(UserRegisterDto dto)
        {
            // Kiểm tra đã tồn tại username chưa
            var existing = await repository.GetByUsernameAsync(dto.TenDangNhap);
            if (existing != null) return null;

            // băm mật khẩu
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.MatKhau);

            var user = new User
            {
                TenDangNhap = dto.TenDangNhap,
                MatKhau = hashedPassword,
                MaVaiTro = dto.MaVaiTro
            };

            var added = await repository.AddUserAsync(user);
            return new UserDto
            {
                Id = added.Id,
                TenDangNhap = added.TenDangNhap,
                MaVaiTro = added.MaVaiTro
            };
        }

        public async Task<UserDto?> LoginAsync(UserLoginDto dto)
        {
            // Tìm theo username thôi
            var user = await repository.GetByUsernameAsync(dto.TenDangNhap);
            if (user == null) return null;

            // So sánh mật khẩu bằng BCrypt
            var isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.MatKhau, user.MatKhau);
            if (!isPasswordValid) return null;

            return new UserDto
            {
                Id = user.Id,
                TenDangNhap = user.TenDangNhap,
                MaVaiTro = user.MaVaiTro
            };
        }

        public async Task<UserDto?> UpdateAsync(int id, UserUpdateDto dto)
        {
            var entity = new User
            {
                Id = id,
                TenDangNhap = dto.TenDangNhap,
                MatKhau = BCrypt.Net.BCrypt.HashPassword(dto.MatKhau),
                MaVaiTro = dto.MaVaiTro
            };

            var updated = await repository.UpdateUserAsync(id, entity);
            if (updated == null) return null;

            return new UserDto
            {
                Id = updated.Id,
                TenDangNhap = updated.TenDangNhap,
                MaVaiTro = updated.MaVaiTro
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteUserAsync(id);
        }
    }
}
