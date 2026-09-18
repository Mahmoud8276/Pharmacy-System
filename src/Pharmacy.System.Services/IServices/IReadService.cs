using Pharmacy.System.Core.Interfaces.ISpecificationParams;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Services.Responses;
using System.Threading.Tasks;

namespace Pharmacy.System.Services.IServices
{
    public interface IReadService<TModel, TKey, TSpecificationParams> 
        where TModel : BaseModel<TKey>
        where TSpecificationParams : IBaseSpecParams

    {
        public Task<Response> GetByIdAsync(TKey id);

        public Task<Response> GetAllAsync(TSpecificationParams specParams);
    }
}
