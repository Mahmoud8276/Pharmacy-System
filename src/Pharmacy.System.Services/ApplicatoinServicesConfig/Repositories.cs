using Pharmacy.System.Core.Interfaces;
using Pharmacy.System.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Pharmacy.System.Services.ApplicatoinServicesConfig
{
    public static class Repositories
    {
        public static IServiceCollection AddRepositoriesConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
