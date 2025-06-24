using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class ExtraShiftService(
        IExtraShiftRepository repository,
        IEmployeeRepository employeeRepository,
        IShiftTypeRepository shiftTypeRepository
    ) : IExtraShiftService
    {
        public async Task<IEnumerable<ExtraShiftDto>> GetAllAsync()
        {
            var data = await repository.GetAllExtraShiftsAsync();
            return data.Select(x => new ExtraShiftDto
            {
                MaTangCa = x.MaTangCa,
                Ngay = x.Ngay,
                SoGio = x.SoGio,
                MaNV = x.MaNV,
                HoTenNV = x.Employee.HoTen,
                MaLoaiCa = x.MaLoaiCa,
                CaLamViec = x.ShiftType.CaLamViec
            });
        }

        public async Task<ExtraShiftDto?> GetByIdAsync(int id)
        {
            var x = await repository.GetExtraShiftByIdAsync(id);
            if (x == null) return null;

            return new ExtraShiftDto
            {
                MaTangCa = x.MaTangCa,
                Ngay = x.Ngay,
                SoGio = x.SoGio,
                MaNV = x.MaNV,
                HoTenNV = x.Employee.HoTen,
                MaLoaiCa = x.MaLoaiCa,
                CaLamViec = x.ShiftType.CaLamViec
            };
        }

        public async Task<ExtraShiftDto> CreateAsync(ExtraShiftInputDto input)
        {
            var entity = new ExtraShift
            {
                Ngay = input.Ngay,
                SoGio = input.SoGio,
                MaNV = input.MaNV,
                MaLoaiCa = input.MaLoaiCa
            };

            var created = await repository.AddExtraShiftAsync(entity);

            var employee = await employeeRepository.GetByIdAsync(created.MaNV);
            var shiftType = await shiftTypeRepository.GetShiftTypeByIdAsync(created.MaLoaiCa);

            return new ExtraShiftDto
            {
                MaTangCa = created.MaTangCa,
                Ngay = created.Ngay,
                SoGio = created.SoGio,
                MaNV = created.MaNV,
                HoTenNV = employee?.HoTen ?? "N/A",
                MaLoaiCa = created.MaLoaiCa,
                CaLamViec = shiftType?.CaLamViec ?? "N/A"
            };
        }

        public async Task<ExtraShiftDto?> UpdateAsync(int id, ExtraShiftInputDto input)
        {
            var entity = new ExtraShift
            {
                Ngay = input.Ngay,
                SoGio = input.SoGio,
                MaNV = input.MaNV,
                MaLoaiCa = input.MaLoaiCa
            };

            var updated = await repository.UpdateExtraShiftAsync(id, entity);
            if (updated == null) return null;

            var employee = await employeeRepository.GetByIdAsync(updated.MaNV);
            var shiftType = await shiftTypeRepository.GetShiftTypeByIdAsync(updated.MaLoaiCa);

            return new ExtraShiftDto
            {
                MaTangCa = updated.MaTangCa,
                Ngay = updated.Ngay,
                SoGio = updated.SoGio,
                MaNV = updated.MaNV,
                HoTenNV = employee?.HoTen ?? "N/A",
                MaLoaiCa = updated.MaLoaiCa,
                CaLamViec = shiftType?.CaLamViec ?? "N/A"
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteExtraShiftAsync(id);
        }
    }
}
