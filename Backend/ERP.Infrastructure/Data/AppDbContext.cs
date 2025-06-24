using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Data
{
    public class AppDbContext (DbContextOptions<AppDbContext> options) : DbContext (options)
    {
        // Mỗi lần tạo 1 entity thì phải tạo DbSet tương ứng trong DbContext
        public DbSet<Allowance> Allowances { get; set; }
        public DbSet<Authorisation> Authorisations { get; set; }
        public DbSet<Authorise> Authorises { get; set; }
        public DbSet<AvailableStock> AvailableStocks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DayType> DayTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAllowance> EmployeeAllowances { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExtraShift> ExtraShifts { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProviderEntity> Providers { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptDetail> ReceiptDetails { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<ShiftType> ShiftTypes { get; set; }
        public DbSet<StockIn> StockIns { get; set; }
        public DbSet<StockInDetail> StockInDetails { get; set; }
        public DbSet<StockOut> StockOuts { get; set; }
        public DbSet<StockOutDetail> StockOutDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkRecord> WorkRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
