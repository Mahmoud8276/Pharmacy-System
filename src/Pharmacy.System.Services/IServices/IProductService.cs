using Pharmacy.System.Core.Dtos.ProductDtos;
using Pharmacy.System.Services.Responses;
using Pharmacy.System.Services.SpecificationParams;
using System.Threading.Tasks;

namespace Pharmacy.System.Services.IServices
{
    public interface IProductService
    {
        public Task<Response> CreateAsync(ProductDto dto);
        public Task<Response> GetAllAsync(ProductSpecParams specParams);
        public Task<Response> GetByIdAsync(int id);
        public Task<Response> UpdateAsync(int id, ProductDto dto);
        public Task<Response> DeleteAsync(int id);
    }
}
