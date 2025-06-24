using ERP.Application.Interfaces;
using ERP.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            // Đăng ký DI cho các Services
            services.AddScoped<IAllowanceService, AllowanceService>();
            services.AddScoped<IAuthorisationService, AuthorisationService>();
            services.AddScoped<IAuthoriseService, AuthoriseService>();
            services.AddScoped<IAvailableStockService, AvailableStockService>();

            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<IDayTypeService, DayTypeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddScoped<IEducationLevelService, EducationLevelService>();
            services.AddScoped<IEmployeeAllowanceService, EmployeeAllowanceService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IExtraShiftService, ExtraShiftService>();

            services.AddScoped<IInsuranceService, InsuranceService>();
            services.AddScoped<IInventoryService, InventoryService>();

            services.AddScoped<IJobTitleService, JobTitleService>();

            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProviderService, ProviderService>();

            services.AddScoped<IReceiptDetailService, ReceiptDetailService>();
            services.AddScoped<IReceiptService, ReceiptService>();
            services.AddScoped<IRevenueService, RevenueService>();
            services.AddScoped<IRolesService, RolesService>();

            services.AddScoped<ISalaryService, SalaryService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<IShiftTypeService, ShiftTypeService>();

            services.AddScoped<IStockInDetailService, StockInDetailService>();
            services.AddScoped<IStockInService, StockInService>();

            services.AddScoped<IStockOutDetailService, StockOutDetailService>();
            services.AddScoped<IStockOutService, StockOutService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWorkRecordService, WorkRecordService>();

            return services;
        }
    }
}
