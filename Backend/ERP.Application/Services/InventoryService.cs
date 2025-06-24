using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class InventoryService(IInventoryRepository repository) : IInventoryService
    {
        public async Task<IEnumerable<InventoryDto>> GetAllInventoriesAsync()
        {
            var entities = await repository.GetAllInventoriesAsync();
            return entities.Select(e => new InventoryDto
            {
                MaKho = e.MaKho,
                TenKho = e.TenKho,
                DiaChi = e.DiaChi,
                NguoiQuanLy = e.NguoiQuanLy,
                GhiChu = e.GhiChu
            });
        }

        public async Task<InventoryDto?> GetInventoryByIdAsync(int id)
        {
            var entity = await repository.GetInventoryByIdAsync(id);
            if (entity == null) return null;

            return new InventoryDto
            {
                MaKho = entity.MaKho,
                TenKho = entity.TenKho,
                DiaChi = entity.DiaChi,
                NguoiQuanLy = entity.NguoiQuanLy,
                GhiChu = entity.GhiChu
            };
        }

        public async Task<InventoryDto> CreateInventoryAsync(InventoryInputDto input)
        {
            var entity = new Inventory
            {
                TenKho = input.TenKho,
                DiaChi = input.DiaChi,
                NguoiQuanLy = input.NguoiQuanLy,
                GhiChu = input.GhiChu
            };

            var created = await repository.AddInventoryAsync(entity);

            return new InventoryDto
            {
                MaKho = created.MaKho,
                TenKho = created.TenKho,
                DiaChi = created.DiaChi,
                NguoiQuanLy = created.NguoiQuanLy,
                GhiChu = created.GhiChu
            };
        }

        public async Task<InventoryDto?> UpdateInventoryAsync(int id, InventoryInputDto input)
        {
            var entity = new Inventory
            {
                TenKho = input.TenKho,
                DiaChi = input.DiaChi,
                NguoiQuanLy = input.NguoiQuanLy,
                GhiChu = input.GhiChu
            };

            var updated = await repository.UpdateInventoryAsync(id, entity);
            if (updated == null) return null;

            return new InventoryDto
            {
                MaKho = updated.MaKho,
                TenKho = updated.TenKho,
                DiaChi = updated.DiaChi,
                NguoiQuanLy = updated.NguoiQuanLy,
                GhiChu = updated.GhiChu
            };
        }

        public async Task<bool> DeleteInventoryAsync(int id)
        {
            return await repository.DeleteInventoryAsync(id);
        }
    }
}
