using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class ReceiptService(IReceiptRepository repository) : IReceiptService
    {
        public async Task<IEnumerable<ReceiptDto>> GetAllAsync()
        {
            var receipts = await repository.GetAllAsync();
            return receipts.Select(r => new ReceiptDto
            {
                MaHD = r.MaHD,
                MaKH = r.MaKH,
                LoaiHD = r.LoaiHD,
                NgayLap = r.NgayLap,
                NguoiLap = r.NguoiLap,
                TongTien = r.TongTien,
                TrangThai = r.TrangThai
            });
        }

        public async Task<ReceiptDto?> GetByIdAsync(int maHD)
        {
            var r = await repository.GetByIdAsync(maHD);
            if (r == null) return null;

            return new ReceiptDto
            {
                MaHD = r.MaHD,
                MaKH = r.MaKH,
                LoaiHD = r.LoaiHD,
                NgayLap = r.NgayLap,
                NguoiLap = r.NguoiLap,
                TongTien = r.TongTien,
                TrangThai = r.TrangThai
            };
        }

        public async Task<ReceiptDto> AddAsync(ReceiptInputDto dto)
        {
            var entity = new Receipt
            {
                MaKH = dto.MaKH,
                LoaiHD = dto.LoaiHD,
                NgayLap = dto.NgayLap,
                NguoiLap = dto.NguoiLap,
                TongTien = dto.TongTien,
                TrangThai = dto.TrangThai
            };

            var result = await repository.AddAsync(entity);

            return new ReceiptDto
            {
                MaHD = result.MaHD,
                MaKH = result.MaKH,
                LoaiHD = result.LoaiHD,
                NgayLap = result.NgayLap,
                NguoiLap = result.NguoiLap,
                TongTien = result.TongTien,
                TrangThai = result.TrangThai
            };
        }

        public async Task<ReceiptDto?> UpdateAsync(int maHD, ReceiptInputDto dto)
        {
            var entity = new Receipt
            {
                MaKH = dto.MaKH,
                LoaiHD = dto.LoaiHD,
                NgayLap = dto.NgayLap,
                NguoiLap = dto.NguoiLap,
                TongTien = dto.TongTien,
                TrangThai = dto.TrangThai
            };

            var updated = await repository.UpdateAsync(maHD, entity);
            if (updated == null) return null;

            return new ReceiptDto
            {
                MaHD = updated.MaHD,
                MaKH = updated.MaKH,
                LoaiHD = updated.LoaiHD,
                NgayLap = updated.NgayLap,
                NguoiLap = updated.NguoiLap,
                TongTien = updated.TongTien,
                TrangThai = updated.TrangThai
            };
        }

        public async Task<bool> DeleteAsync(int maHD)
        {
            return await repository.DeleteAsync(maHD);
        }
    }
}
