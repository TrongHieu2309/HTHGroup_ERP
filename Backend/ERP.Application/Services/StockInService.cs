using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class StockInService(IStockInRepository repository) : IStockInService
    {
        public async Task<IEnumerable<StockInDto>> GetAllAsync()
        {
            var entities = await repository.GetAllStockInsAsync();
            return entities.Select(x => new StockInDto
            {
                MaPhieuNhap = x.MaPhieuNhap,
                MaNCC = x.MaNCC,
                MaKho = x.MaKho,
                NgayNhap = x.NgayNhap,
                GhiChu = x.GhiChu
            });
        }

        public async Task<StockInDto?> GetByIdAsync(int id)
        {
            var entity = await repository.GetStockInByIdAsync(id);
            if (entity == null) return null;

            return new StockInDto
            {
                MaPhieuNhap = entity.MaPhieuNhap,
                MaNCC = entity.MaNCC,
                MaKho = entity.MaKho,
                NgayNhap = entity.NgayNhap,
                GhiChu = entity.GhiChu
            };
        }

        public async Task<StockInDto> CreateAsync(StockInInputDto input)
        {
            var entity = new StockIn
            {
                MaNCC = input.MaNCC,
                MaKho = input.MaKho,
                NgayNhap = input.NgayNhap,
                GhiChu = input.GhiChu
            };

            var created = await repository.AddStockInAsync(entity);

            return new StockInDto
            {
                MaPhieuNhap = created.MaPhieuNhap,
                MaNCC = created.MaNCC,
                MaKho = created.MaKho,
                NgayNhap = created.NgayNhap,
                GhiChu = created.GhiChu
            };
        }

        public async Task<StockInDto?> UpdateAsync(int id, StockInInputDto input)
        {
            var entity = new StockIn
            {
                MaNCC = input.MaNCC,
                MaKho = input.MaKho,
                NgayNhap = input.NgayNhap,
                GhiChu = input.GhiChu
            };

            var updated = await repository.UpdateStockInAsync(id, entity);
            if (updated == null) return null;

            return new StockInDto
            {
                MaPhieuNhap = updated.MaPhieuNhap,
                MaNCC = updated.MaNCC,
                MaKho = updated.MaKho,
                NgayNhap = updated.NgayNhap,
                GhiChu = updated.GhiChu
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteStockInAsync(id);
        }
    }
}
