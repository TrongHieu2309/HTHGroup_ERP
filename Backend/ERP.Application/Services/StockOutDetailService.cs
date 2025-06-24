using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class StockOutDetailService(IStockOutDetailRepository repository) : IStockOutDetailService
    {
        public async Task<IEnumerable<StockOutDetailDto>> GetAllAsync()
        {
            var items = await repository.GetAllAsync();
            return items.Select(d => new StockOutDetailDto
            {
                Id = d.Id,
                MaPhieuXuat = d.MaPhieuXuat,
                MaSP = d.MaSP,
                SoLuongXuat = d.SoLuongXuat,
                GhiChu = d.GhiChu,
                TenSanPham = d.Product?.TenSanPham
            });
        }

        public async Task<StockOutDetailDto?> GetByIdAsync(int id)
        {
            var d = await repository.GetByIdAsync(id);
            if (d == null) return null;

            return new StockOutDetailDto
            {
                Id = d.Id,
                MaPhieuXuat = d.MaPhieuXuat,
                MaSP = d.MaSP,
                SoLuongXuat = d.SoLuongXuat,
                GhiChu = d.GhiChu,
                TenSanPham = d.Product?.TenSanPham
            };
        }

        public async Task<IEnumerable<StockOutDetailDto>> GetByStockOutIdAsync(int maPhieuXuat)
        {
            var items = await repository.GetByStockOutIdAsync(maPhieuXuat);
            return items.Select(d => new StockOutDetailDto
            {
                Id = d.Id,
                MaPhieuXuat = d.MaPhieuXuat,
                MaSP = d.MaSP,
                SoLuongXuat = d.SoLuongXuat,
                GhiChu = d.GhiChu,
                TenSanPham = d.Product?.TenSanPham
            });
        }

        public async Task<StockOutDetailDto> CreateAsync(StockOutDetailInputDto input)
        {
            var entity = new StockOutDetail
            {
                MaPhieuXuat = input.MaPhieuXuat,
                MaSP = input.MaSP,
                SoLuongXuat = input.SoLuongXuat,
                GhiChu = input.GhiChu
            };

            var result = await repository.AddStockOutDetailAsync(entity);

            return new StockOutDetailDto
            {
                Id = result.Id,
                MaPhieuXuat = result.MaPhieuXuat,
                MaSP = result.MaSP,
                SoLuongXuat = result.SoLuongXuat,
                GhiChu = result.GhiChu
            };
        }

        public async Task<StockOutDetailDto?> UpdateAsync(int id, StockOutDetailInputDto input)
        {
            var updated = await repository.UpdateStockOutDetailAsync(id, new StockOutDetail
            {
                MaPhieuXuat = input.MaPhieuXuat,
                MaSP = input.MaSP,
                SoLuongXuat = input.SoLuongXuat,
                GhiChu = input.GhiChu
            });

            if (updated == null) return null;

            return new StockOutDetailDto
            {
                Id = updated.Id,
                MaPhieuXuat = updated.MaPhieuXuat,
                MaSP = updated.MaSP,
                SoLuongXuat = updated.SoLuongXuat,
                GhiChu = updated.GhiChu
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteStockOutDetailAsync(id);
        }
    }
}
