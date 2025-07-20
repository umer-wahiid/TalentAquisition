using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TalentAquisition.Core.Interfaces;
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

            // Add other infrastructure services here
            // services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
