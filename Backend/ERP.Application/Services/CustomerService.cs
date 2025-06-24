using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class CustomerService(ICustomerRepository repository) : ICustomerService
    {
        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await repository.GetAllAsync();
            return customers.Select(c => new CustomerDto
            {
                MaKH = c.MaKH,
                TenKhachHang = c.TenKhachHang,
                DiaChi = c.DiaChi,
                SoDienThoai = c.SoDienThoai,
                Email = c.Email,
                GhiChu = c.GhiChu,
                TichDiem = c.TichDiem
            });
        }

        public async Task<CustomerDto?> GetByIdAsync(int id)
        {
            var c = await repository.GetByIdAsync(id);
            return c is null ? null : new CustomerDto
            {
                MaKH = c.MaKH,
                TenKhachHang = c.TenKhachHang,
                DiaChi = c.DiaChi,
                SoDienThoai = c.SoDienThoai,
                Email = c.Email,
                GhiChu = c.GhiChu,
                TichDiem = c.TichDiem
            };
        }

        public async Task<CustomerDto> CreateAsync(CustomerInputDto input)
        {
            var entity = new Customer
            {
                TenKhachHang = input.TenKhachHang,
                DiaChi = input.DiaChi,
                SoDienThoai = input.SoDienThoai,
                Email = input.Email,
                GhiChu = input.GhiChu,
                TichDiem = input.TichDiem
            };

            var created = await repository.AddAsync(entity);

            return new CustomerDto
            {
                MaKH = created.MaKH,
                TenKhachHang = created.TenKhachHang,
                DiaChi = created.DiaChi,
                SoDienThoai = created.SoDienThoai,
                Email = created.Email,
                GhiChu = created.GhiChu,
                TichDiem = created.TichDiem
            };
        }

        public async Task<CustomerDto?> UpdateAsync(int id, CustomerInputDto input)
        {
            var entity = new Customer
            {
                TenKhachHang = input.TenKhachHang,
                DiaChi = input.DiaChi,
                SoDienThoai = input.SoDienThoai,
                Email = input.Email,
                GhiChu = input.GhiChu,
                TichDiem = input.TichDiem
            };

            var updated = await repository.UpdateAsync(id, entity);

            return updated is null ? null : new CustomerDto
            {
                MaKH = updated.MaKH,
                TenKhachHang = updated.TenKhachHang,
                DiaChi = updated.DiaChi,
                SoDienThoai = updated.SoDienThoai,
                Email = updated.Email,
                GhiChu = updated.GhiChu,
                TichDiem = updated.TichDiem
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
