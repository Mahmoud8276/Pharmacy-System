
namespace Pharmacy.System.Core.Interfaces.ISpecificationParams
{
    public interface IProductSpecParams : IBaseSpecParams
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public int? ManufacturerId { get; set; }
    }
}
