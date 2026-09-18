using Pharmacy.System.Core.Interfaces;
using Pharmacy.System.Infrastructure.DataSeeders;
using Pharmacy.System.Infrastructure.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Pharmacy.System.Services.ApplicatoinServicesConfig
{
    public static class DataSeeders
    {
        public static IServiceCollection AddDataSeedersConfigurations(this IServiceCollection serviceCollection)
        {
            var infrastructureAssembly = typeof(AppDbContext).Assembly;
            var assimblyName = infrastructureAssembly.GetName().Name;

            var seederTypes = infrastructureAssembly
                                  .GetTypes()
                                  .Where(t => typeof(IDataSeeder).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var type in seederTypes)
                serviceCollection.AddScoped(typeof(IDataSeeder), type);

            serviceCollection.AddScoped<DataSeedersRunner>();

            return serviceCollection;
        }

    }
}
