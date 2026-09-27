using Pharmacy.System.Core.Interfaces.IRepositories;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Infrastructure.DbContexts;

namespace Pharmacy.System.Infrastructure.Repositories
{
    public class BaseUnitRepository : GenericRepository<BaseUnit, int>, IBaseUnitRepository
    {
        private readonly AppDbContext _context;
        public BaseUnitRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
