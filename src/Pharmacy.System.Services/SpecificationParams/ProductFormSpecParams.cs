using Pharmacy.System.Core.Interfaces.ISpecificationParams;

namespace Pharmacy.System.Services.SpecificationParams
{
    public class ProductFormSpecParams : BaseSpecParams, IProductFormSpecParams
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
