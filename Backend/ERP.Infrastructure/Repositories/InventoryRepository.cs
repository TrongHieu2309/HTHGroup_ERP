using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class InventoryRepository(AppDbContext dbContext) : IInventoryRepository
    {
        public async Task<IEnumerable<Inventory>> GetAllInventoriesAsync()
        {
            return await dbContext.Inventories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Inventory?> GetInventoryByIdAsync(int id)
        {
            return await dbContext.Inventories
                .FirstOrDefaultAsync(i => i.MaKho == id);
        }

        public async Task<Inventory> AddInventoryAsync(Inventory inventory)
        {
            dbContext.Inventories.Add(inventory);
            await dbContext.SaveChangesAsync();
            return inventory;
        }

        public async Task<Inventory?> UpdateInventoryAsync(int id, Inventory inventory)
        {
            var existing = await dbContext.Inventories.FindAsync(id);
            if (existing == null) return null;

            // Update fields
            existing.TenKho = inventory.TenKho;
            existing.DiaChi = inventory.DiaChi;
            existing.NguoiQuanLy = inventory.NguoiQuanLy;
            existing.GhiChu = inventory.GhiChu;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteInventoryAsync(int id)
        {
            var entity = await dbContext.Inventories.FindAsync(id);
            if (entity == null) return false;

            dbContext.Inventories.Remove(entity);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
