using Pharmacy.System.Core.Models;

namespace Pharmacy.System.Services.Specifications
{
    public class ProductPackagingLevelSpecification : BaseSpecification<ProductPackagingLevel, int>
    {
        public ProductPackagingLevelSpecification(int levelId) : base(x=>x.Id == levelId) 
        {
            AddInclude(x => x.Product);
            AddInclude(x => x.PackagingUnit);
        }

        public ProductPackagingLevelSpecification(int? productId, int? packagingUnitId)
            : base(x=> 
            (!productId.HasValue || x.ProductId == productId) &&
            (!packagingUnitId.HasValue || x.PackagingUnitId == packagingUnitId))
        {
            AddInclude(x => x.Product);
            AddInclude(x => x.PackagingUnit);
        }
    }
}
