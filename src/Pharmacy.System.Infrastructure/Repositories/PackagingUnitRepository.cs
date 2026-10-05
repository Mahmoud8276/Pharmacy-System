using Pharmacy.System.Core.Interfaces.IRepositories;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Infrastructure.DbContexts;


namespace Pharmacy.System.Infrastructure.Repositories
{
    public class PackagingUnitRepository : GenericRepository<PackagingUnit, int>, IPackagingUnitRepository
    {
        public PackagingUnitRepository(AppDbContext context) : base(context)
        {
        }
    }
}
