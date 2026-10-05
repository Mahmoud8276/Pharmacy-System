using Microsoft.EntityFrameworkCore;
using Pharmacy.System.Core.Interfaces.IRepositories;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Infrastructure.DbContexts;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.System.Infrastructure.Repositories
{
    public class ProductPackagingLevelRepository :
        GenericRepository<ProductPackagingLevel, int>,
        IProductPackagingLevelRepository
    {
        private readonly AppDbContext _context;
        public ProductPackagingLevelRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ProductPackagingLevel?> GetChildPackagingLevelAsync(int parentPackagingLevelId)
        {
            return await _context.ProductPackagingLevels
                .Include(x=>x.PackagingUnit)
                .Include(x=>x.Product)
                 .Where(x=>x.ParentId == parentPackagingLevelId)
                 .FirstOrDefaultAsync();
        }
    }
}
