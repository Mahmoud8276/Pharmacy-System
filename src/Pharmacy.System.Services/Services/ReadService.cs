using Pharmacy.System.Core.Dtos;
using Pharmacy.System.Core.Interfaces;
using Pharmacy.System.Core.Interfaces.IRepositories;
using Pharmacy.System.Core.Interfaces.ISpecificationParams;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Services.IServices;
using Pharmacy.System.Services.Responses;
using Mapster;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Pharmacy.System.Services.Services
{
    public abstract class ReadService<TModel, TKey, TSpecificationParams, TDetailsDto> :
        IReadService<TModel, TKey, TSpecificationParams>
        where TModel : BaseModel<TKey>
        where TDetailsDto : class
        where TSpecificationParams : IBaseSpecParams
    {

        protected readonly IGenericRepository<TModel, TKey> _repository;
        protected ReadService(IGenericRepository<TModel, TKey> repository)
        {
            _repository = repository;
        }

        protected abstract ISpecification<TModel, TKey> BuildSpec(TSpecificationParams specParams, bool isCountQuery);


        public async Task<Response> GetAllAsync(TSpecificationParams specParams)
        {
            var spec = BuildSpec(specParams, false);
            var data = await _repository.GetAllWithSpecAsync(spec);

            var countSpec = BuildSpec(specParams, true);
            var count = await _repository.GetCountWithSpecAsync(countSpec);

            var pagination = new Pagination(specParams.PageIndex, specParams.PageSize, count, data.Adapt<List<TDetailsDto>>());

            return Response.Success(pagination);
        }

        public async Task<Response> GetByIdAsync(TKey id)
        {
            var resource = await _repository.GetByIdAsync(id);
            if(resource == null)
            {
                return Response.Fail(message: "resource not found", statusCode: (int)HttpStatusCode.NotFound);
            }

            return Response.Success(data: resource.Adapt<TDetailsDto>(), statusCode: (int)HttpStatusCode.OK);
        }
    }
}
