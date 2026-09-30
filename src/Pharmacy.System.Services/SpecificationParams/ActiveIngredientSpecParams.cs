using Pharmacy.System.Core.Interfaces.ISpecificationParams;

namespace Pharmacy.System.Services.SpecificationParams
{
    public class ActiveIngredientSpecParams : BaseSpecParams ,IActiveIngredientSpecParams
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}
