using Pharmacy.System.Core.Models;
using System.Threading.Tasks;

namespace Pharmacy.System.Core.Interfaces.IRepositories
{
    public interface IProductPackagingLevelRepository : IGenericRepository<ProductPackagingLevel, int>
    {
        public Task<ProductPackagingLevel?> GetChildPackagingLevelAsync(int parentPackagingLevelId);
    }
}
