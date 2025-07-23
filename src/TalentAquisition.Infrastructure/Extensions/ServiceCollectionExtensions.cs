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
            // Register DbContext
            services.AddDbContext<TalentAquisitionDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register repositories
            services.AddScoped<ISetupStatusRepository, SetupStatusRepository>();
            services.AddScoped<IMainFieldRepository, MainFieldRepository>();
            services.AddScoped<IDropdownRepository, DropdownRepository>();

            // Add other infrastructure services here
            services.AddScoped<ISetupStatusService, SetupStatusService>();
            services.AddScoped<IMainFieldService, MainFieldService>();
            services.AddScoped<IDropdownService, DropdownService>();

            return services;
        }
    }
}
