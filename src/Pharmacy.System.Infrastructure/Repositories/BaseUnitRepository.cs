using Pharmacy.System.Core.Interfaces.IRepositories;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Infrastructure.DbContexts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Pharmacy.System.Infrastructure.Repositories
{
    public class BaseUnitRepository : GenericRepository<BaseUnit, int>, IBaseUnitRepository
    {
        private readonly AppDbContext _context;
        public BaseUnitRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BaseUnit?> GetByProductIdAsync(int productId)
        {
            return await _context.Products
                .Where(product=> product.Id == productId)
                .Select(product => product.ProductForm.BaseUnit)    
                .FirstOrDefaultAsync();
        }
    }
}
