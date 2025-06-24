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
                Id = d.Id,
                MaPhongBan = d.MaPhongBan,
                TenPhongBan = d.TenPhongBan
            });
        }

        public async Task<DepartmentDto?> GetByIdAsync(int id)
        {
            var d = await repository.GetByIdAsync(id);
            return d is null ? null : new DepartmentDto
            {
                Id = d.Id,
                MaPhongBan = d.MaPhongBan,
                TenPhongBan = d.TenPhongBan
            };
        }

        public async Task<DepartmentDto> CreateAsync(DepartmentInputDto input)
        {
            var department = new Department
            {
                MaPhongBan = input.MaPhongBan,
                TenPhongBan = input.TenPhongBan
            };

            var created = await repository.AddAsync(department);
            return new DepartmentDto
            {
                Id = created.Id,
                MaPhongBan = created.MaPhongBan,
                TenPhongBan = created.TenPhongBan
            };
        }

        public async Task<DepartmentDto?> UpdateAsync(int id, DepartmentInputDto input)
        {
            var updated = await repository.UpdateAsync(id, new Department
            {
                MaPhongBan = input.MaPhongBan,
                TenPhongBan = input.TenPhongBan
            });

            return updated is null ? null : new DepartmentDto
            {
                Id = updated.Id,
                MaPhongBan = updated.MaPhongBan,
                TenPhongBan = updated.TenPhongBan
            };
        }

        public async Task<bool> DeleteAsync(int id) => await repository.DeleteAsync(id);
    }
}
