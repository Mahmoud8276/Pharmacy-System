using Pharmacy.System.Core.Interfaces.IRepositories;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Infrastructure.DbContexts;

namespace Pharmacy.System.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product, int>, IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
