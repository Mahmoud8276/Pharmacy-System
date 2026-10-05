using Pharmacy.System.Core.Models;
using System.Threading.Tasks;

namespace Pharmacy.System.Core.Interfaces.IRepositories
{
    public interface IBaseUnitRepository : IGenericRepository<BaseUnit, int>
    {
        public Task<BaseUnit?> GetByProductIdAsync(int productId);
    }
}
