using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class StockOutService(IStockOutRepository repository) : IStockOutService
    {
        public async Task<IEnumerable<StockOutDto>> GetAllAsync()
        {
            var data = await repository.GetAllAsync();
            return data.Select(x => new StockOutDto
            {
                MaPhieuXuat = x.MaPhieuXuat,
                MaKho = x.MaKho,
                NguoiXuat = x.NguoiXuat,
                NgayXuat = x.NgayXuat,
                LyDoXuat = x.LyDoXuat
            });
        }

        public async Task<StockOutDto?> GetByIdAsync(int id)
        {
            var x = await repository.GetByIdAsync(id);
            if (x == null) return null;

            return new StockOutDto
            {
                MaPhieuXuat = x.MaPhieuXuat,
                MaKho = x.MaKho,
                NguoiXuat = x.NguoiXuat,
                NgayXuat = x.NgayXuat,
                LyDoXuat = x.LyDoXuat
            };
        }

        public async Task<StockOutDto> CreateAsync(StockOutInputDto input)
        {
            var entity = new StockOut
            {
                MaKho = input.MaKho,
                NguoiXuat = input.NguoiXuat,
                NgayXuat = input.NgayXuat,
                LyDoXuat = input.LyDoXuat
            };

            var created = await repository.AddStockOutAsync(entity);

            return new StockOutDto
            {
                MaPhieuXuat = created.MaPhieuXuat,
                MaKho = created.MaKho,
                NguoiXuat = created.NguoiXuat,
                NgayXuat = created.NgayXuat,
                LyDoXuat = created.LyDoXuat
            };
        }

        public async Task<StockOutDto?> UpdateAsync(int id, StockOutInputDto input)
        {
            var entity = new StockOut
            {
                MaKho = input.MaKho,
                NguoiXuat = input.NguoiXuat,
                NgayXuat = input.NgayXuat,
                LyDoXuat = input.LyDoXuat
            };

            var updated = await repository.UpdateStockOutAsync(id, entity);
            if (updated == null) return null;

            return new StockOutDto
            {
                MaPhieuXuat = updated.MaPhieuXuat,
                MaKho = updated.MaKho,
                NguoiXuat = updated.NguoiXuat,
                NgayXuat = updated.NgayXuat,
                LyDoXuat = updated.LyDoXuat
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteStockOutAsync(id);
        }
    }
}
