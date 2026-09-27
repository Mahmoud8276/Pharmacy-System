using Pharmacy.System.Core.Interfaces.IRepositories;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Infrastructure.DbContexts;

namespace Pharmacy.System.Infrastructure.Repositories
{
    public class ManufactorerRepository : GenericRepository<Manufacturer, int>, IManufactorerRepository
    {
        private readonly AppDbContext _context;
        public ManufactorerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
