using Pharmacy.System.Core.Interfaces.IRepositories;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Infrastructure.DbContexts;

namespace Pharmacy.System.Infrastructure.Repositories
{
    public class ProductActiveIngredientRepository : GenericRepository<ProductActiveIngredient, int>, IProductActiveIngredientRepository
    {
        public ProductActiveIngredientRepository(AppDbContext context) : base(context)
        {
        }
    }
}
