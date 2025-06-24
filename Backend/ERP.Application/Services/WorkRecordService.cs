using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class WorkRecordService(IWorkRecordRepository repository) : IWorkRecordService
    {
        public async Task<IEnumerable<WorkRecordDto>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            return entities.Select(w => new WorkRecordDto
            {
                MaTinhCong = w.MaTinhCong,
                Ngay = w.Ngay,
                GioVao = w.GioVao,
                GioRa = w.GioRa,
                MaNhanVien = w.MaNhanVien,
                MaLoaiCong = w.MaLoaiCong,
                HoTenNhanVien = w.Employee.HoTen
            });
        }

        public async Task<WorkRecordDto?> GetByIdAsync(int id)
        {
            var w = await repository.GetByIdAsync(id);
            if (w is null) return null;

            return new WorkRecordDto
            {
                MaTinhCong = w.MaTinhCong,
                Ngay = w.Ngay,
                GioVao = w.GioVao,
                GioRa = w.GioRa,
                MaNhanVien = w.MaNhanVien,
                MaLoaiCong = w.MaLoaiCong,
                HoTenNhanVien = w.Employee.HoTen
            };
        }

        public async Task<WorkRecordDto> CreateAsync(WorkRecordInputDto input)
        {
            var entity = new WorkRecord
            {
                Ngay = input.Ngay,
                GioVao = input.GioVao,
                GioRa = input.GioRa,
                MaNhanVien = input.MaNhanVien,
                MaLoaiCong = input.MaLoaiCong
            };

            var created = await repository.AddAsync(entity);

            // Load lại để có Employee.HoTen
            var result = await repository.GetByIdAsync(created.MaTinhCong);

            return new WorkRecordDto
            {
                MaTinhCong = result!.MaTinhCong,
                Ngay = result.Ngay,
                GioVao = result.GioVao,
                GioRa = result.GioRa,
                MaNhanVien = result.MaNhanVien,
                MaLoaiCong = result.MaLoaiCong,
                HoTenNhanVien = result.Employee.HoTen
            };
        }

        public async Task<WorkRecordDto?> UpdateAsync(int id, WorkRecordInputDto input)
        {
            var entity = new WorkRecord
            {
                Ngay = input.Ngay,
                GioVao = input.GioVao,
                GioRa = input.GioRa,
                MaNhanVien = input.MaNhanVien,
                MaLoaiCong = input.MaLoaiCong
            };

            var updated = await repository.UpdateAsync(id, entity);
            if (updated is null) return null;

            var result = await repository.GetByIdAsync(updated.MaTinhCong);

            return new WorkRecordDto
            {
                MaTinhCong = result!.MaTinhCong,
                Ngay = result.Ngay,
                GioVao = result.GioVao,
                GioRa = result.GioRa,
                MaNhanVien = result.MaNhanVien,
                MaLoaiCong = result.MaLoaiCong,
                HoTenNhanVien = result.Employee.HoTen
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
