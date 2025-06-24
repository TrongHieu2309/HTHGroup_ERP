using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class ProviderRepository(AppDbContext dbContext) : IProviderRepository
    {
        // Thêm Nhà cung cấp mới
        public async Task<ProviderEntity> AddProviderAsync(ProviderEntity entity)
        {
            entity.Id = 0; // Assuming Id is auto-incremented in the database
            dbContext.Providers.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        // GET ALL Providers
        public async Task<IEnumerable<ProviderEntity>> GetProviders()
        {
            return await dbContext.Providers.ToListAsync();
        }

        // GET Provider by Id
        public async Task<ProviderEntity> GetProviderByIdAsync(int id)
        {
            return await dbContext.Providers.FirstOrDefaultAsync(x => x.Id == id);
        }

        // UPDATE Nhà cung cấp
        public async Task<ProviderEntity> UpdateProviderAsync(int id, ProviderEntity entity)
        {
            var provider = await dbContext.Providers.FirstOrDefaultAsync(x => x.Id == id);
            if (provider != null)
            {
                provider.MaNCC = entity.MaNCC;
                provider.TenNCC = entity.TenNCC;
                provider.DiaChi = entity.DiaChi;
                provider.MoTa = entity.MoTa;
                provider.SoDienThoai = entity.SoDienThoai;
                provider.Email = entity.Email;
                provider.NguoiTiepNhan = entity.NguoiTiepNhan;
                await dbContext.SaveChangesAsync();
                return provider;
            }
            return entity;
        }

        // DELETE Nhà cung cấp
        public async Task<bool> DeleteProviderAsync(int id)
        {
            var provider = await dbContext.Providers.FirstOrDefaultAsync(x => x.Id == id);
            if (provider != null)
            {
                dbContext.Providers.Remove(provider);
                return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
