using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class ExpenseRepository(AppDbContext dbContext) : IExpenseRepository
    {
        public async Task<Expense> AddExpenseAsync(Expense entity)
        {
            await dbContext.Expenses.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            return await dbContext.Expenses
                .Include(x => x.Employee) // nếu cần thông tin nhân viên đi kèm
                .ToListAsync();
        }

        public async Task<Expense?> GetExpenseByIdAsync(int id)
        {
            return await dbContext.Expenses
                .Include(x => x.Employee)
                .FirstOrDefaultAsync(x => x.MaChi == id);
        }

        public async Task<Expense?> UpdateExpenseAsync(int id, Expense entity)
        {
            var existing = await dbContext.Expenses.FirstOrDefaultAsync(x => x.MaChi == id);
            if (existing is null) return null;

            existing.MaNV = entity.MaNV;
            existing.NgayChi = entity.NgayChi;
            existing.NoiDung = entity.NoiDung;
            existing.SoTien = entity.SoTien;
            existing.NguoiChi = entity.NguoiChi;
            existing.GhiChu = entity.GhiChu;

            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteExpenseAsync(int id)
        {
            var entity = await dbContext.Expenses.FirstOrDefaultAsync(x => x.MaChi == id);
            if (entity is null) return false;

            dbContext.Expenses.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
