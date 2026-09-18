using Pharmacy.System.Core.Models;
using System.Threading.Tasks;

namespace Pharmacy.System.Services.IServices
{
    public interface ITokenService
    {
        public Task<string> GenerateAccessTokenAsync(AppUser user);
        public RefreshToken GenerateRefreshToken();
    }
}
