using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class ExpenseService(IExpenseRepository repository, IEmployeeRepository employeeRepository) : IExpenseService
    {
        public async Task<IEnumerable<ExpenseDto>> GetAllExpensesAsync()
        {
            var entities = await repository.GetAllExpensesAsync();
            return entities.Select(x => new ExpenseDto
            {
                MaChi = x.MaChi,
                MaNV = x.MaNV,
                HoTenNV = x.Employee.HoTen,
                NgayChi = x.NgayChi,
                NoiDung = x.NoiDung,
                SoTien = x.SoTien,
                NguoiChi = x.NguoiChi,
                GhiChu = x.GhiChu
            });
        }

        public async Task<ExpenseDto?> GetExpenseByIdAsync(int id)
        {
            var entity = await repository.GetExpenseByIdAsync(id);
            if (entity is null) return null;

            return new ExpenseDto
            {
                MaChi = entity.MaChi,
                MaNV = entity.MaNV,
                HoTenNV = entity.Employee.HoTen,
                NgayChi = entity.NgayChi,
                NoiDung = entity.NoiDung,
                SoTien = entity.SoTien,
                NguoiChi = entity.NguoiChi,
                GhiChu = entity.GhiChu
            };
        }

        public async Task<ExpenseDto> CreateExpenseAsync(ExpenseInputDto input)
        {
            var entity = new Expense
            {
                MaNV = input.MaNV,
                NgayChi = input.NgayChi,
                NoiDung = input.NoiDung,
                SoTien = input.SoTien,
                NguoiChi = input.NguoiChi,
                GhiChu = input.GhiChu
            };

            var created = await repository.AddExpenseAsync(entity);
            var employee = await employeeRepository.GetByIdAsync(created.MaNV);

            return new ExpenseDto
            {
                MaChi = created.MaChi,
                MaNV = created.MaNV,
                HoTenNV = employee?.HoTen ?? "",
                NgayChi = created.NgayChi,
                NoiDung = created.NoiDung,
                SoTien = created.SoTien,
                NguoiChi = created.NguoiChi,
                GhiChu = created.GhiChu
            };
        }

        public async Task<ExpenseDto?> UpdateExpenseAsync(int id, ExpenseInputDto input)
        {
            var entity = new Expense
            {
                MaNV = input.MaNV,
                NgayChi = input.NgayChi,
                NoiDung = input.NoiDung,
                SoTien = input.SoTien,
                NguoiChi = input.NguoiChi,
                GhiChu = input.GhiChu
            };

            var updated = await repository.UpdateExpenseAsync(id, entity);
            if (updated is null) return null;

            var employee = await employeeRepository.GetByIdAsync(updated.MaNV);

            return new ExpenseDto
            {
                MaChi = updated.MaChi,
                MaNV = updated.MaNV,
                HoTenNV = employee?.HoTen ?? "",
                NgayChi = updated.NgayChi,
                NoiDung = updated.NoiDung,
                SoTien = updated.SoTien,
                NguoiChi = updated.NguoiChi,
                GhiChu = updated.GhiChu
            };
        }

        public async Task<bool> DeleteExpenseAsync(int id)
        {
            return await repository.DeleteExpenseAsync(id);
        }
    }
}
