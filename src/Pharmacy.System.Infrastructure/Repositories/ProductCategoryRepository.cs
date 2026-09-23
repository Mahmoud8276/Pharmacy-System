using Pharmacy.System.Core.Interfaces.IRepositories;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Infrastructure.DbContexts;

namespace Pharmacy.System.Infrastructure.Repositories
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory, int>, IProductCategoryRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
