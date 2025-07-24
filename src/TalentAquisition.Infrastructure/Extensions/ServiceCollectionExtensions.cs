using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TalentAquisition.Core.IRepositories;
using TalentAquisition.Core.IServices;
using TalentAquisition.Infrastructure.Context;
using TalentAquisition.Infrastructure.Repositories;

namespace TalentAquisition.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TalentAquisitionDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ISetupStatusService, SetupStatusService>();
            services.AddScoped<ISetupStatusRepository, SetupStatusRepository>();

            services.AddScoped<IMainFieldService, MainFieldService>();
            services.AddScoped<IMainFieldRepository, MainFieldRepository>();
            
            services.AddScoped<IMainEmployeeService, MainEmployeeService>();
            services.AddScoped<IMainEmployeeRepository, MainEmployeeRepository>();
            
            services.AddScoped<IDropdownRepository, DropdownRepository>();
            services.AddScoped<IDropdownService, DropdownService>();

            return services;
        }
    }
}
