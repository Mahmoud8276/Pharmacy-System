using Pharmacy.System.Core.Interfaces.IRepositories;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Infrastructure.DbContexts;

namespace Pharmacy.System.Infrastructure.Repositories
{
    public class ProductPackagingLevelRepository :
        GenericRepository<ProductPackagingLevel, int>,
        IProductPackagingLevelRepository
    {
        public ProductPackagingLevelRepository(AppDbContext context) : base(context)
        {
        }
    }
}
