using Pharmacy.System.Core.Dtos.ProductPackagingDtos;
using Pharmacy.System.Services.Responses;
using System.Threading.Tasks;

namespace Pharmacy.System.Services.IServices
{
    public interface IProductPackagingService
    {
        public Task<Response> CreateAsync(int productId, ProductPackagingDto dto);
        public Task<Response> GetProductPackagingLevelsAsync(int productId);
        public Task<Response> UpdateAsync(int productId, int ProductPackagingId, UpdateProductPackagingDto dto);
        public Task<Response> DeleteAsync(int productId, int ProductPackagingId);
        public Task<Response> DeleteProductPackagingLevelsAsync(int productId);
        public Task<Response> GetProductBaseUnit(int productId);
    }
}
