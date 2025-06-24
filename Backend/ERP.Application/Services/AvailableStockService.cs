using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class AvailableStockService(IAvailableStockRepository repository) : IAvailableStockService
    {
        public async Task<IEnumerable<AvailableStockDto>> GetAllAsync()
        {
            var stocks = await repository.GetAllAsync();
            return stocks.Select(x => new AvailableStockDto
            {
                Id = x.Id,
                MaSP = x.MaSP,
                TenSP = x.TenSP,
                MaKho = x.MaKho,
                SoLuongTon = x.SoLuongTon,
                NgayCapNhat = x.NgayCapNhat
            });
        }

        public async Task<AvailableStockDto?> GetByIdAsync(int id)
        {
            var x = await repository.GetByIdAsync(id);
            if (x == null) return null;

            return new AvailableStockDto
            {
                Id = x.Id,
                MaSP = x.MaSP,
                TenSP = x.TenSP,
                MaKho = x.MaKho,
                SoLuongTon = x.SoLuongTon,
                NgayCapNhat = x.NgayCapNhat
            };
        }

        public async Task<AvailableStockDto> CreateAsync(AvailableStockInputDto input)
        {
            var entity = new AvailableStock
            {
                MaSP = input.MaSP,
                TenSP = input.TenSP,
                MaKho = input.MaKho,
                SoLuongTon = input.SoLuongTon,
                NgayCapNhat = input.NgayCapNhat ?? DateTime.Now
            };

            var created = await repository.AddAsync(entity);

            return new AvailableStockDto
            {
                Id = created.Id,
                MaSP = created.MaSP,
                TenSP = created.TenSP,
                MaKho = created.MaKho,
                SoLuongTon = created.SoLuongTon,
                NgayCapNhat = created.NgayCapNhat
            };
        }

        public async Task<AvailableStockDto?> UpdateAsync(int id, AvailableStockInputDto input)
        {
            var entity = new AvailableStock
            {
                MaSP = input.MaSP,
                TenSP = input.TenSP,
                MaKho = input.MaKho,
                SoLuongTon = input.SoLuongTon,
                NgayCapNhat = input.NgayCapNhat ?? DateTime.Now
            };

            var updated = await repository.UpdateAsync(id, entity);
            if (updated == null) return null;

            return new AvailableStockDto
            {
                Id = updated.Id,
                MaSP = updated.MaSP,
                TenSP = updated.TenSP,
                MaKho = updated.MaKho,
                SoLuongTon = updated.SoLuongTon,
                NgayCapNhat = updated.NgayCapNhat
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
