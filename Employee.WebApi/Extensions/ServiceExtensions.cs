using Employees.Contracts;
using Employees.Contracts.Interface.IAddEditEmployeeRepository;
using Employees.Entities;
using Employees.Entities.Context;
using Employees.LoggerService;
using Employees.Repository;
using Employees.Repository.Models.AddEditEmployeeRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Employees.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

        // add IIS configure options deploy to IIS
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<AdventureWorks2019Context>(options =>
            options.UseSqlServer(configuration.GetConnectionString("development")
                ));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureAddEditEmployeeRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IAddEditEmployeeRepositoryManager, AddEditEmployeeRepositoryManager>();
    }
}
