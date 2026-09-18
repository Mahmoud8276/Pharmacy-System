using Pharmacy.System.Core.Dtos.AppUserDtos;
using Pharmacy.System.Core.Models;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pharmacy.System.Services.ApplicatoinServicesConfig
{
    public static class MappingProfiles
    {
        public static IServiceCollection AddMappingProfilesConfigurations(
            this IServiceCollection services,
            IConfiguration config)
        {
            var BaseUrl = config["Storage:BaseUrl"];


            TypeAdapterConfig<AppUser, UserDetailsDto>
                .NewConfig()
                .Map(dest => dest.ImageUrl, src => $"{BaseUrl}/files/UserImages/{src.Image}");

            return services;
        }
    }
}
