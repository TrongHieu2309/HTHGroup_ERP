using ERP.Core.Interfaces;
using ERP.Core.Options;
using ERP.Infrastructure.Data;
using ERP.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ERP.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });

            // Phải đăng ký DbContext trước khi đăng ký các repository
            services.AddScoped<IAllowanceRepository, AllowanceRepository>();
            services.AddScoped<IAuthorisationRepository, AuthorisationRepository>();
            services.AddScoped<IAuthoriseRepository, AuthoriseRepository>();
            services.AddScoped<IAvailableStockRepository, AvailableStockRepository>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IDayTypeRepository, DayTypeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            services.AddScoped<IEducationLevelRepository, EducationLevelRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeAllowanceRepository, EmployeeAllowanceRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IExtraShiftRepository, ExtraShiftRepository>();

            services.AddScoped<IInsuranceRepository, InsuranceRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();

            services.AddScoped<IJobTitleRepository, JobTitleRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();

            services.AddScoped<IReceiptRepository, ReceiptRepository>();
            services.AddScoped<IReceiptDetailRepository, ReceiptDetailRepository>();
            services.AddScoped<IRevenueRepository, RevenueRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();

            services.AddScoped<ISalaryRepository, SalaryRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<IShiftTypeRepository, ShiftTypeRepository>();

            services.AddScoped<IStockInRepository, StockInRepository>();
            services.AddScoped<IStockInDetailRepository, StockInDetailRepository>();

            services.AddScoped<IStockOutRepository, StockOutRepository>();
            services.AddScoped<IStockOutDetailRepository, StockOutDetailRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWorkRecordRepository, WorkRecordRepository>();

            return services;
        }
    }
}
