using Pharmacy.System.Core.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pharmacy.System.Services.ApplicatoinServicesConfig
{
    public static class Options
    {
        public static IServiceCollection AddOptionsConfigurations(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.Configure<EmailOptions>(configuration.GetSection("Email"));
            services.Configure<JwtOptions>(configuration.GetSection("Jwt"));

            return services;
        }
    }
}
