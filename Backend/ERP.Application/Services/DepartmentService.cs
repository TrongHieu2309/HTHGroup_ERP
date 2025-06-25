using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class DepartmentService(IDepartmentRepository repository) : IDepartmentService
    {
        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var departments = await repository.GetAllAsync();
            return departments.Select(d => new DepartmentDto
            {
                MaPhongBan = d.MaPhongBan,
                TenPhongBan = d.TenPhongBan
            });
        }

        public async Task<DepartmentDto?> GetByIdAsync(int id)
        {
            var d = await repository.GetByIdAsync(id);
            return d is null ? null : new DepartmentDto
            {
                MaPhongBan = d.MaPhongBan,
                TenPhongBan = d.TenPhongBan
            };
        }

        public async Task<DepartmentDto> CreateAsync(DepartmentInputDto input)
        {
            var department = new Department
            {
                TenPhongBan = input.TenPhongBan
            };

            var created = await repository.AddAsync(department);
            return new DepartmentDto
            {
                MaPhongBan = created.MaPhongBan,
                TenPhongBan = created.TenPhongBan
            };
        }

        public async Task<DepartmentDto?> UpdateAsync(int id, DepartmentInputDto input)
        {
            var updated = await repository.UpdateAsync(id, new Department
            {
                TenPhongBan = input.TenPhongBan
            });

            return updated is null ? null : new DepartmentDto
            {
                MaPhongBan = updated.MaPhongBan,
                TenPhongBan = updated.TenPhongBan
            };
        }

        public async Task<bool> DeleteAsync(int id) => await repository.DeleteAsync(id);
    }
}
