using Microsoft.Extensions.DependencyInjection;
using sample_netcore.Domain.Loggers;
using sample_netcore.Domain.Services;

namespace sample_netcore.Domain.Extensions.Configurations
{
    public static class ServicesExtension
    {
        public static void ConfigureDataService(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<IDishService, DishService>();
            services.AddScoped<IBillingService, BillingService>();
        }

        public static void ConfigurePackageService(this IServiceCollection services)
        {
            // Register Nlogging
            services.AddSingleton<INLogConfiguration, NLogConfiguration>();
        }
    }
}
