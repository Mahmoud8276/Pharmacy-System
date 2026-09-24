
namespace Pharmacy.System.Core.Interfaces.ISpecificationParams
{
    public interface IProductCategorySpecParams : IBaseSpecParams
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
