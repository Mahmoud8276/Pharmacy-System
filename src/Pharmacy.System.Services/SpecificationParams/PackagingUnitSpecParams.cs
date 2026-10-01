
using Pharmacy.System.Core.Interfaces.ISpecificationParams;

namespace Pharmacy.System.Services.SpecificationParams
{
    public class PackagingUnitSpecParams : BaseSpecParams, IPackagingUnitSpecParams
    {
        public string? Name { get; set; }
        public string? Symbol { get; set; }
    }
}
