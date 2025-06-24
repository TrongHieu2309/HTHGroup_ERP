using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class EmployeeService(IEmployeeRepository repository) : IEmployeeService
    {
        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await repository.GetAllAsync();
            return employees.Select(e => new EmployeeDto
            {
                MaNV = e.MaNV,
                HoTen = e.HoTen,
                NgaySinh = e.NgaySinh,
                GioiTinh = e.GioiTinh,
                SoDienThoai = e.SoDienThoai,
                CCCD = e.CCCD,
                Email = e.Email,
                DiaChi = e.DiaChi,
                MaPhongBan = e.MaPhongBan,
                MaBoPhan = e.MaBoPhan,
                MaChucVu = e.MaChucVu,
                MaTDHV = e.MaTDHV
            });
        }

        public async Task<EmployeeDto?> GetByIdAsync(int maNV)
        {
            var e = await repository.GetByIdAsync(maNV);
            if (e == null) return null;

            return new EmployeeDto
            {
                MaNV = e.MaNV,
                HoTen = e.HoTen,
                NgaySinh = e.NgaySinh,
                GioiTinh = e.GioiTinh,
                SoDienThoai = e.SoDienThoai,
                CCCD = e.CCCD,
                Email = e.Email,
                DiaChi = e.DiaChi,
                MaPhongBan = e.MaPhongBan,
                MaBoPhan = e.MaBoPhan,
                MaChucVu = e.MaChucVu,
                MaTDHV = e.MaTDHV
            };
        }

        public async Task<EmployeeDto> CreateAsync(EmployeeInputDto input)
        {
            var entity = new Employee
            {
                HoTen = input.HoTen,
                NgaySinh = input.NgaySinh,
                GioiTinh = input.GioiTinh,
                SoDienThoai = input.SoDienThoai,
                CCCD = input.CCCD,
                Email = input.Email,
                DiaChi = input.DiaChi,
                MaPhongBan = input.MaPhongBan,
                MaBoPhan = input.MaBoPhan,
                MaChucVu = input.MaChucVu,
                MaTDHV = input.MaTDHV
            };

            var result = await repository.AddAsync(entity);

            return new EmployeeDto
            {
                MaNV = result.MaNV,
                HoTen = result.HoTen,
                NgaySinh = result.NgaySinh,
                GioiTinh = result.GioiTinh,
                SoDienThoai = result.SoDienThoai,
                CCCD = result.CCCD,
                Email = result.Email,
                DiaChi = result.DiaChi,
                MaPhongBan = result.MaPhongBan,
                MaBoPhan = result.MaBoPhan,
                MaChucVu = result.MaChucVu,
                MaTDHV = result.MaTDHV
            };
        }

        public async Task<EmployeeDto?> UpdateAsync(int maNV, EmployeeInputDto input)
        {
            var entity = new Employee
            {
                HoTen = input.HoTen,
                NgaySinh = input.NgaySinh,
                GioiTinh = input.GioiTinh,
                SoDienThoai = input.SoDienThoai,
                CCCD = input.CCCD,
                Email = input.Email,
                DiaChi = input.DiaChi,
                MaPhongBan = input.MaPhongBan,
                MaBoPhan = input.MaBoPhan,
                MaChucVu = input.MaChucVu,
                MaTDHV = input.MaTDHV
            };

            var updated = await repository.UpdateAsync(maNV, entity);
            if (updated is null) return null;

            return new EmployeeDto
            {
                MaNV = updated.MaNV,
                HoTen = updated.HoTen,
                NgaySinh = updated.NgaySinh,
                GioiTinh = updated.GioiTinh,
                SoDienThoai = updated.SoDienThoai,
                CCCD = updated.CCCD,
                Email = updated.Email,
                DiaChi = updated.DiaChi,
                MaPhongBan = updated.MaPhongBan,
                MaBoPhan = updated.MaBoPhan,
                MaChucVu = updated.MaChucVu,
                MaTDHV = updated.MaTDHV
            };
        }

        public async Task<bool> DeleteAsync(int maNV)
        {
            return await repository.DeleteAsync(maNV);
        }
    }
}
