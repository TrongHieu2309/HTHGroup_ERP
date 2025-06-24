using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class ReceiptDetailService(IReceiptDetailRepository repository) : IReceiptDetailService
    {
        public async Task<IEnumerable<ReceiptDetailDto>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            return entities.Select(x => new ReceiptDetailDto
            {
                Id = x.Id,
                MaHD = x.MaHD,
                MaSP = x.MaSP,
                SoLuong = x.SoLuong,
                DonGia = x.DonGia,
                ChietKhau = x.ChietKhau,
                VAT = x.VAT,
                GhiChu = x.GhiChu
            });
        }

        public async Task<ReceiptDetailDto?> GetByIdAsync(int id)
        {
            var entity = await repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new ReceiptDetailDto
            {
                Id = entity.Id,
                MaHD = entity.MaHD,
                MaSP = entity.MaSP,
                SoLuong = entity.SoLuong,
                DonGia = entity.DonGia,
                ChietKhau = entity.ChietKhau,
                VAT = entity.VAT,
                GhiChu = entity.GhiChu
            };
        }

        public async Task<ReceiptDetailDto> CreateAsync(ReceiptDetailInputDto input)
        {
            var entity = new ReceiptDetail
            {
                MaHD = input.MaHD,
                MaSP = input.MaSP,
                SoLuong = input.SoLuong,
                DonGia = input.DonGia,
                ChietKhau = input.ChietKhau,
                VAT = input.VAT,
                GhiChu = input.GhiChu
            };

            var created = await repository.AddAsync(entity);

            return new ReceiptDetailDto
            {
                Id = created.Id,
                MaHD = created.MaHD,
                MaSP = created.MaSP,
                SoLuong = created.SoLuong,
                DonGia = created.DonGia,
                ChietKhau = created.ChietKhau,
                VAT = created.VAT,
                GhiChu = created.GhiChu
            };
        }

        public async Task<ReceiptDetailDto?> UpdateAsync(int id, ReceiptDetailInputDto input)
        {
            var entity = new ReceiptDetail
            {
                MaHD = input.MaHD,
                MaSP = input.MaSP,
                SoLuong = input.SoLuong,
                DonGia = input.DonGia,
                ChietKhau = input.ChietKhau,
                VAT = input.VAT,
                GhiChu = input.GhiChu
            };

            var updated = await repository.UpdateAsync(id, entity);
            if (updated == null) return null;

            return new ReceiptDetailDto
            {
                Id = updated.Id,
                MaHD = updated.MaHD,
                MaSP = updated.MaSP,
                SoLuong = updated.SoLuong,
                DonGia = updated.DonGia,
                ChietKhau = updated.ChietKhau,
                VAT = updated.VAT,
                GhiChu = updated.GhiChu
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
