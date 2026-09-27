using Pharmacy.System.Core.Interfaces.IRepositories;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Infrastructure.DbContexts;

namespace Pharmacy.System.Infrastructure.Repositories
{
    public class ProductFormRepository : GenericRepository<ProductForm, int>, IProductFormRepository
    {
        private readonly AppDbContext _context;
        public ProductFormRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
