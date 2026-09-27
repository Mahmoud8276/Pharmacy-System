using Pharmacy.System.Core.Interfaces.ISpecificationParams;

namespace Pharmacy.System.Services.SpecificationParams
{
    public class ProductSpecParams : BaseSpecParams, IProductSpecParams
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public int? ManufacturerId { get; set; }

    }
}
