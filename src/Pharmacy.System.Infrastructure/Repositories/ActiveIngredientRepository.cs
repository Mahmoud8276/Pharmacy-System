using Pharmacy.System.Core.Interfaces.IRepositories;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Infrastructure.DbContexts;

namespace Pharmacy.System.Infrastructure.Repositories
{
    public class ActiveIngredientRepository : GenericRepository<ActiveIngredient, int>, IActiveIngredientRepository
    {
        public ActiveIngredientRepository(AppDbContext context) : base(context)
        {
        }
    }
}
