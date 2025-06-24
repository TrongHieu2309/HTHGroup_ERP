using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class ProviderService(IProviderRepository repo) : IProviderService
    {
        public async Task<IEnumerable<ProviderDto>> GetAllProvidersAsync()
        => (await repo.GetProviders())
           .Select(p => new ProviderDto
           {
               Id = p.Id,
               MaNCC = p.MaNCC,
               TenNCC = p.TenNCC,
               DiaChi = p.DiaChi,
               MoTa = p.MoTa,
               SoDienThoai = p.SoDienThoai,
               Email = p.Email,
               NguoiTiepNhan = p.NguoiTiepNhan
           });

        public async Task<ProviderDto?> GetProviderByIdAsync(int id)
        {
            var p = await repo.GetProviderByIdAsync(id);
            return p is null ? null : new ProviderDto
            {
                Id = p.Id,
                MaNCC = p.MaNCC,
                TenNCC = p.TenNCC,
                DiaChi = p.DiaChi,
                MoTa = p.MoTa,
                SoDienThoai = p.SoDienThoai,
                Email = p.Email,
                NguoiTiepNhan = p.NguoiTiepNhan
            };
        }

        public async Task<ProviderDto> AddProviderAsync(ProviderInputDto input)
        {
            var entity = new ProviderEntity
            {
                MaNCC = input.MaNCC,
                TenNCC = input.TenNCC,
                DiaChi = input.DiaChi,
                MoTa = input.MoTa,
                SoDienThoai = input.SoDienThoai,
                Email = input.Email,
                NguoiTiepNhan = input.NguoiTiepNhan
            };

            var result = await repo.AddProviderAsync(entity);

            return new ProviderDto
            {
                Id = result.Id,
                MaNCC = result.MaNCC,
                TenNCC = result.TenNCC,
                DiaChi = result.DiaChi,
                MoTa = result.MoTa,
                SoDienThoai = result.SoDienThoai,
                Email = result.Email,
                NguoiTiepNhan = result.NguoiTiepNhan
            };
        }

        public async Task<ProviderDto?> UpdateProviderAsync(int id, ProviderInputDto input)
        {
            var entity = new ProviderEntity
            {
                Id = id, // Gán Id để repository biết cập nhật bản ghi nào
                MaNCC = input.MaNCC,
                TenNCC = input.TenNCC,
                DiaChi = input.DiaChi,
                MoTa = input.MoTa,
                SoDienThoai = input.SoDienThoai,
                Email = input.Email,
                NguoiTiepNhan = input.NguoiTiepNhan
            };

            var updated = await repo.UpdateProviderAsync(id, entity);
            return updated.Id != id ? null : new ProviderDto
            {
                Id = updated.Id,
                MaNCC = updated.MaNCC,
                TenNCC = updated.TenNCC,
                DiaChi = updated.DiaChi,
                MoTa = updated.MoTa,
                SoDienThoai = updated.SoDienThoai,
                Email = updated.Email,
                NguoiTiepNhan = updated.NguoiTiepNhan
            };
        }

        public Task<bool> DeleteProviderAsync(int id)
            => repo.DeleteProviderAsync(id);
    }
}
