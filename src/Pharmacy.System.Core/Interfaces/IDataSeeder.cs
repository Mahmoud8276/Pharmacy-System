using System.Threading;
using System.Threading.Tasks;

namespace Pharmacy.System.Core.Interfaces
{
    public interface IDataSeeder
    {
        public int Order { get; }

        public Task SeedAsync(CancellationToken token = default);
    }
}
