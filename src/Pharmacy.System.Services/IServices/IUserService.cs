using Pharmacy.System.Services.Responses;
using Pharmacy.System.Services.SpecificationParams;
using System.Threading.Tasks;

namespace Pharmacy.System.Services.IServices
{
    public interface IUserService
    {
        Task<Response> GetByIdAsync(string id);
        Task<Response> GetAllAsync(UserSpecParams specParams);
    }
}
