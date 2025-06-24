using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class RevenueService(IRevenueRepository repository) : IRevenueService
    {
        public async Task<IEnumerable<RevenueDto>> GetAllRevenuesAsync()
        {
            var entities = await repository.GetRevenues();
            return entities.Select(x => new RevenueDto
            {
                MaThu = x.MaThu,
                MaNV = x.MaNV,
                NgayThu = x.NgayThu,
                NoiDung = x.NoiDung,
                SoTien = x.SoTien,
                NguoiThu = x.NguoiThu,
                GhiChu = x.GhiChu
            });
        }

        public async Task<RevenueDto?> GetRevenueByIdAsync(int id)
        {
            var entity = await repository.GetRevenueByIdAsync(id);
            if (entity == null) return null;

            return new RevenueDto
            {
                MaThu = entity.MaThu,
                MaNV = entity.MaNV,
                NgayThu = entity.NgayThu,
                NoiDung = entity.NoiDung,
                SoTien = entity.SoTien,
                NguoiThu = entity.NguoiThu,
                GhiChu = entity.GhiChu
            };
        }

        public async Task<RevenueDto> CreateRevenueAsync(RevenueInputDto input)
        {
            var entity = new Revenue
            {
                MaNV = input.MaNV,
                NgayThu = input.NgayThu.Date,
                NoiDung = input.NoiDung,
                SoTien = input.SoTien,
                NguoiThu = input.NguoiThu,
                GhiChu = input.GhiChu
            };

            var created = await repository.AddRevenueAsync(entity);

            return new RevenueDto
            {
                MaThu = created.MaThu,
                MaNV = created.MaNV,
                NgayThu = created.NgayThu,
                NoiDung = created.NoiDung,
                SoTien = created.SoTien,
                NguoiThu = created.NguoiThu,
                GhiChu = created.GhiChu
            };
        }

        public async Task<RevenueDto?> UpdateRevenueAsync(int id, RevenueInputDto input)
        {
            var entity = new Revenue
            {
                MaNV = input.MaNV,
                NgayThu = input.NgayThu.Date,
                NoiDung = input.NoiDung,
                SoTien = input.SoTien,
                NguoiThu = input.NguoiThu,
                GhiChu = input.GhiChu
            };

            var updated = await repository.UpdateRevenueAsync(id, entity);
            if (updated == null) return null;

            return new RevenueDto
            {
                MaThu = updated.MaThu,
                MaNV = updated.MaNV,
                NgayThu = updated.NgayThu,
                NoiDung = updated.NoiDung,
                SoTien = updated.SoTien,
                NguoiThu = updated.NguoiThu,
                GhiChu = updated.GhiChu
            };
        }

        public async Task<bool> DeleteRevenueAsync(int id)
        {
            return await repository.DeleteRevenueAsync(id);
        }
    }
}
