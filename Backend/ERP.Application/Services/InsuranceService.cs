using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class InsuranceService(IInsuranceRepository repository) : IInsuranceService
    {
        public async Task<IEnumerable<InsuranceDto>> GetAllInsurancesAsync()
        {
            var entities = await repository.GetInsurancesAsync();
            return entities.Select(i => new InsuranceDto
            {
                MaBH = i.MaBH,
                MaNV = i.MaNV,
                LoaiBH = i.LoaiBH,
                SoBH = i.SoBH,
                BenhVien = i.BenhVien,
                NgayCap = i.NgayCap,
                NgayHetHan = i.NgayHetHan,
                TinhTrang = i.TinhTrang
            });
        }

        public async Task<InsuranceDto?> GetInsuranceByIdAsync(int id)
        {
            var entity = await repository.GetInsuranceByIdAsync(id);
            if (entity == null) return null;

            return new InsuranceDto
            {
                MaBH = entity.MaBH,
                MaNV = entity.MaNV,
                LoaiBH = entity.LoaiBH,
                SoBH = entity.SoBH,
                BenhVien = entity.BenhVien,
                NgayCap = entity.NgayCap,
                NgayHetHan = entity.NgayHetHan,
                TinhTrang = entity.TinhTrang
            };
        }

        public async Task<InsuranceDto> CreateInsuranceAsync(InsuranceInputDto input)
        {
            var entity = new Insurance
            {
                MaNV = input.MaNV,
                LoaiBH = input.LoaiBH,
                SoBH = input.SoBH,
                BenhVien = input.BenhVien,
                NgayCap = input.NgayCap,
                NgayHetHan = input.NgayHetHan,
                TinhTrang = input.TinhTrang
            };

            var created = await repository.AddInsuranceAsync(entity);

            return new InsuranceDto
            {
                MaBH = created.MaBH,
                MaNV = created.MaNV,
                LoaiBH = created.LoaiBH,
                SoBH = created.SoBH,
                BenhVien = created.BenhVien,
                NgayCap = created.NgayCap,
                NgayHetHan = created.NgayHetHan,
                TinhTrang = created.TinhTrang
            };
        }

        public async Task<InsuranceDto?> UpdateInsuranceAsync(int id, InsuranceInputDto input)
        {
            var entity = new Insurance
            {
                MaNV = input.MaNV,
                LoaiBH = input.LoaiBH,
                SoBH = input.SoBH,
                BenhVien = input.BenhVien,
                NgayCap = input.NgayCap,
                NgayHetHan = input.NgayHetHan,
                TinhTrang = input.TinhTrang
            };

            var updated = await repository.UpdateInsuranceAsync(id, entity);
            if (updated == null) return null;

            return new InsuranceDto
            {
                MaBH = updated.MaBH,
                MaNV = updated.MaNV,
                LoaiBH = updated.LoaiBH,
                SoBH = updated.SoBH,
                BenhVien = updated.BenhVien,
                NgayCap = updated.NgayCap,
                NgayHetHan = updated.NgayHetHan,
                TinhTrang = updated.TinhTrang
            };
        }

        public async Task<bool> DeleteInsuranceAsync(int id)
        {
            return await repository.DeleteInsuranceAsync(id);
        }
    }
}
