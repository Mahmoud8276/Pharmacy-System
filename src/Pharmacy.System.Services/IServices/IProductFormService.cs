using Pharmacy.System.Core.Dtos.ProductFormDtos;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Services.SpecificationParams;

namespace Pharmacy.System.Services.IServices
{
    public interface IProductFormService : IWriteService<ProductForm, int, ProductFormDto, ProductFormDto, ProductFormSpecParams>
    {
    }
}
