using Pharmacy.System.Core.Models;
using Pharmacy.System.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Pharmacy.System.Services.ApplicatoinServicesConfig
{
    public static class Identity
    {
        public static IServiceCollection AddIdentityConfigurations(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, UserRole>(options =>
            {

            }).AddRoles<UserRole>()
              .AddEntityFrameworkStores<AppDbContext>()
              .AddSignInManager()
              .AddDefaultTokenProviders();


            return services;
        }
    }
}
