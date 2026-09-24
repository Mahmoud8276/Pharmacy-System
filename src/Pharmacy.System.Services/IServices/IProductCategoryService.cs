using Pharmacy.System.Core.Dtos.ProductCategoryDtos;
using Pharmacy.System.Services.Responses;
using Pharmacy.System.Services.SpecificationParams;
using System.Threading.Tasks;

namespace Pharmacy.System.Services.IServices
{
    public interface IProductCategoryService
    {
        public Task<Response> CreateAsync(ProductCategoryDto dto);
        public Task<Response> GetAllAsync(ProductCategorySpecParams specParams);
        public Task<Response> GetByIdAsync(int id);
        public Task<Response> UpdateAsync(ProductCategoryDto dto, int id);
        public Task<Response> DeleteAsync(int id);
    }
}
