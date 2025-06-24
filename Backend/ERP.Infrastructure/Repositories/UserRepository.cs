using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext dbContext) : IUserRepository
    {
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await dbContext.Users.Include(u => u.Roles).ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await dbContext.Users.Include(u => u.Roles)
                                        .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await dbContext.Users.Include(u => u.Roles)
                                        .FirstOrDefaultAsync(u => u.TenDangNhap == username);
        }

        public async Task<User> AddUserAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateUserAsync(int id, User updatedUser)
        {
            var existing = await dbContext.Users.FindAsync(id);
            if (existing == null) return null;

            existing.TenDangNhap = updatedUser.TenDangNhap;
            existing.MatKhau = updatedUser.MatKhau;
            existing.MaVaiTro = updatedUser.MaVaiTro;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user == null) return false;

            dbContext.Users.Remove(user);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            return await dbContext.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.TenDangNhap == username && u.MatKhau == password);
        }
    }
}
