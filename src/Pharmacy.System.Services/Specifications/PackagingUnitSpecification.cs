using Pharmacy.System.Core.Interfaces.ISpecificationParams;
using Pharmacy.System.Core.Models;
using System.Linq.Expressions;
using System;

namespace Pharmacy.System.Services.Specifications
{
    public class PackagingUnitSpecification : BaseSpecification<PackagingUnit, int>
    {
        public PackagingUnitSpecification(IPackagingUnitSpecParams specParams, bool isCount = false) : base(BuildCriteria(specParams))
        {
            if (!isCount)
            {
                ApplyPagination((specParams.PageIndex - 1) * specParams.PageSize, specParams.PageSize);
                AddOrderBy(x => x.Name);
            }
        }

        private static Expression<Func<PackagingUnit, bool>> BuildCriteria(IPackagingUnitSpecParams specParams)
        {
            var name = specParams.Name?.ToLower();
            var symbol = specParams.Symbol?.ToLower();

            return x =>
                (string.IsNullOrEmpty(name) || x.Name.ToLower().Contains(name)) &&
                (string.IsNullOrEmpty(symbol) || x.Symbol.ToLower().Contains(symbol));        
        }
    }
}
