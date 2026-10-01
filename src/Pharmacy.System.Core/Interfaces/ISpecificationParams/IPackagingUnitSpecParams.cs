
namespace Pharmacy.System.Core.Interfaces.ISpecificationParams
{
    public interface IPackagingUnitSpecParams : IBaseSpecParams
    {
        public string? Name { get; set; }
        public string? Symbol { get; set; }
    }
}
