using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class EmployeeAllowanceService(IEmployeeAllowanceRepository repository) : IEmployeeAllowanceService
    {
        public async Task<IEnumerable<EmployeeAllowanceDto>> GetAllAsync()
        {
            var list = await repository.GetAllAsync();
            return list.Select(ea => new EmployeeAllowanceDto
            {
                MaPhuCapNV = ea.MaPhuCapNV,
                MaNV = ea.MaNV,
                MaPC = ea.MaPC,
                Thang = ea.Thang,
                Nam = ea.Nam,
                SoTien = ea.SoTien
            });
        }

        public async Task<EmployeeAllowanceDto?> GetByIdAsync(int id)
        {
            var ea = await repository.GetByIdAsync(id);
            if (ea is null) return null;

            return new EmployeeAllowanceDto
            {
                MaPhuCapNV = ea.MaPhuCapNV,
                MaNV = ea.MaNV,
                MaPC = ea.MaPC,
                Thang = ea.Thang,
                Nam = ea.Nam,
                SoTien = ea.SoTien
            };
        }

        public async Task<EmployeeAllowanceDto> AddAsync(EmployeeAllowanceInputDto dto)
        {
            var entity = new EmployeeAllowance
            {
                MaNV = dto.MaNV,
                MaPC = dto.MaPC,
                Thang = dto.Thang,
                Nam = dto.Nam,
                SoTien = dto.SoTien
            };

            var added = await repository.AddAsync(entity);

            return new EmployeeAllowanceDto
            {
                MaPhuCapNV = added.MaPhuCapNV,
                MaNV = added.MaNV,
                MaPC = added.MaPC,
                Thang = added.Thang,
                Nam = added.Nam,
                SoTien = added.SoTien
            };
        }

        public async Task<EmployeeAllowanceDto?> UpdateAsync(int id, EmployeeAllowanceInputDto dto)
        {
            var entity = new EmployeeAllowance
            {
                MaNV = dto.MaNV,
                MaPC = dto.MaPC,
                Thang = dto.Thang,
                Nam = dto.Nam,
                SoTien = dto.SoTien
            };

            var updated = await repository.UpdateAsync(id, entity);
            if (updated is null) return null;

            return new EmployeeAllowanceDto
            {
                MaPhuCapNV = updated.MaPhuCapNV,
                MaNV = updated.MaNV,
                MaPC = updated.MaPC,
                Thang = updated.Thang,
                Nam = updated.Nam,
                SoTien = updated.SoTien
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
