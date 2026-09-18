using Pharmacy.System.Core.Interfaces.ISpecificationParams;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Services.Responses;
using System.Threading.Tasks;

namespace Pharmacy.System.Services.IServices
{
    public interface IWriteService<TModel, TKey, TCreateDto, TUpdateDto, TSpecificationParams> 
        : IReadService<TModel, TKey, TSpecificationParams>
        where TModel : BaseModel<TKey>
        where TCreateDto : class
        where TUpdateDto : class
        where TSpecificationParams: IBaseSpecParams
    {
        public Task<Response> CreateAsync(TCreateDto dto);
        public Task<Response> UpdateAsync(TUpdateDto dto, TKey id);
        public Task<Response> DeleteAsync(TKey id);
    }
}
