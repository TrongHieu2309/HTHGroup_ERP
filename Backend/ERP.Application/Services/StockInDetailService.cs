using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class StockInDetailService(IStockInDetailRepository repository) : IStockInDetailService
    {
        public async Task<IEnumerable<StockInDetailDto>> GetAllAsync()
        {
            var list = await repository.GetAllAsync();
            return list.Select(d => new StockInDetailDto
            {
                Id = d.Id,
                MaPhieuNhap = d.MaPhieuNhap,
                MaSP = d.MaSP,
                TenSP = d.Product.TenSanPham,
                SoLuongNhap = d.SoLuongNhap,
                DonGia = d.DonGia
            });
        }

        public async Task<IEnumerable<StockInDetailDto>> GetByStockInIdAsync(int maPhieuNhap)
        {
            var list = await repository.GetByStockInIdAsync(maPhieuNhap);
            return list.Select(d => new StockInDetailDto
            {
                Id = d.Id,
                MaPhieuNhap = d.MaPhieuNhap,
                MaSP = d.MaSP,
                TenSP = d.Product.TenSanPham,
                SoLuongNhap = d.SoLuongNhap,
                DonGia = d.DonGia
            });
        }

        public async Task<StockInDetailDto?> GetByIdAsync(int id)
        {
            var d = await repository.GetByIdAsync(id);
            if (d == null) return null;

            return new StockInDetailDto
            {
                Id = d.Id,
                MaPhieuNhap = d.MaPhieuNhap,
                MaSP = d.MaSP,
                TenSP = d.Product.TenSanPham,
                SoLuongNhap = d.SoLuongNhap,
                DonGia = d.DonGia
            };
        }

        public async Task<StockInDetailDto> AddAsync(StockInDetailInputDto dto)
        {
            var entity = new StockInDetail
            {
                MaPhieuNhap = dto.MaPhieuNhap,
                MaSP = dto.MaSP,
                SoLuongNhap = dto.SoLuongNhap,
                DonGia = dto.DonGia
            };

            var result = await repository.AddStockInDetailAsync(entity);

            return new StockInDetailDto
            {
                Id = result.Id,
                MaPhieuNhap = result.MaPhieuNhap,
                MaSP = result.MaSP,
                TenSP = result.Product?.TenSanPham ?? "",
                SoLuongNhap = result.SoLuongNhap,
                DonGia = result.DonGia
            };
        }

        public async Task<StockInDetailDto?> UpdateAsync(int id, StockInDetailInputDto dto)
        {
            var entity = new StockInDetail
            {
                MaPhieuNhap = dto.MaPhieuNhap,
                MaSP = dto.MaSP,
                SoLuongNhap = dto.SoLuongNhap,
                DonGia = dto.DonGia
            };

            var updated = await repository.UpdateStockInDetailAsync(id, entity);
            if (updated == null) return null;

            return new StockInDetailDto
            {
                Id = updated.Id,
                MaPhieuNhap = updated.MaPhieuNhap,
                MaSP = updated.MaSP,
                TenSP = updated.Product?.TenSanPham ?? "",
                SoLuongNhap = updated.SoLuongNhap,
                DonGia = updated.DonGia
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteStockInDetailAsync(id);
        }
    }
}
