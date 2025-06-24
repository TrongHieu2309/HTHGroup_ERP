using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class SalaryService(ISalaryRepository repository) : ISalaryService
    {
        public async Task<IEnumerable<SalaryDto>> GetAllSalariesAsync()
        {
            var entities = await repository.GetSalariesAsync();
            return entities.Select(s => new SalaryDto
            {
                MaLuong = s.MaLuong,
                MaNV = s.MaNV,
                Thang = s.Thang,
                Nam = s.Nam,
                LuongCoBan = s.LuongCoBan,
                TongTC = s.TongTC,
                TongPC = s.TongPC,
                ThucLinh = s.ThucLinh
            });
        }

        public async Task<SalaryDto?> GetSalaryByIdAsync(int id)
        {
            var s = await repository.GetSalaryByIdAsync(id);
            if (s is null) return null;

            return new SalaryDto
            {
                MaLuong = s.MaLuong,
                MaNV = s.MaNV,
                Thang = s.Thang,
                Nam = s.Nam,
                LuongCoBan = s.LuongCoBan,
                TongTC = s.TongTC,
                TongPC = s.TongPC,
                ThucLinh = s.ThucLinh
            };
        }

        public async Task<SalaryDto> CreateSalaryAsync(SalaryInputDto input)
        {
            var entity = new Salary
            {
                MaNV = input.MaNV,
                Thang = input.Thang,
                Nam = input.Nam,
                LuongCoBan = input.LuongCoBan,
                TongTC = input.TongTC,
                TongPC = input.TongPC
            };

            var created = await repository.AddSalaryAsync(entity);

            return new SalaryDto
            {
                MaLuong = created.MaLuong,
                MaNV = created.MaNV,
                Thang = created.Thang,
                Nam = created.Nam,
                LuongCoBan = created.LuongCoBan,
                TongTC = created.TongTC,
                TongPC = created.TongPC,
                ThucLinh = created.ThucLinh
            };
        }

        public async Task<SalaryDto?> UpdateSalaryAsync(int id, SalaryInputDto input)
        {
            var entity = new Salary
            {
                MaNV = input.MaNV,
                Thang = input.Thang,
                Nam = input.Nam,
                LuongCoBan = input.LuongCoBan,
                TongTC = input.TongTC,
                TongPC = input.TongPC
            };

            var updated = await repository.UpdateSalaryAsync(id, entity);
            if (updated is null) return null;

            return new SalaryDto
            {
                MaLuong = updated.MaLuong,
                MaNV = updated.MaNV,
                Thang = updated.Thang,
                Nam = updated.Nam,
                LuongCoBan = updated.LuongCoBan,
                TongTC = updated.TongTC,
                TongPC = updated.TongPC,
                ThucLinh = updated.ThucLinh
            };
        }

        public async Task<bool> DeleteSalaryAsync(int id)
        {
            return await repository.DeleteSalaryAsync(id);
        }
    }
}
