using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly AppDbContext _dbContext;

        public ProviderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Thêm Nhà cung cấp mới
        public async Task<ProviderEntity> AddProviderAsync(ProviderEntity entity)
        {
            await _dbContext.Providers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        // Lấy tất cả Nhà cung cấp
        public async Task<IEnumerable<ProviderEntity>> GetProviders()
        {
            return await _dbContext.Providers.ToListAsync();
        }

        // Lấy nhà cung cấp theo Id
        public async Task<ProviderEntity?> GetProviderByIdAsync(int id)
        {
            return await _dbContext.Providers.FindAsync(id);
        }

        // Cập nhật Nhà cung cấp
        public async Task<ProviderEntity?> UpdateProviderAsync(int id, ProviderEntity entity)
        {
            var existing = await _dbContext.Providers.FindAsync(id);
            if (existing == null) return null;

            existing.TenNCC = entity.TenNCC;
            existing.DiaChi = entity.DiaChi;
            existing.MoTa = entity.MoTa;
            existing.SoDienThoai = entity.SoDienThoai;
            existing.Email = entity.Email;
            existing.NguoiTiepNhan = entity.NguoiTiepNhan;

            await _dbContext.SaveChangesAsync();
            return existing;
        }

        // Xóa Nhà cung cấp
        public async Task<bool> DeleteProviderAsync(int id)
        {
            var provider = await _dbContext.Providers.FindAsync(id);
            if (provider == null) return false;

            _dbContext.Providers.Remove(provider);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
