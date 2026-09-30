using Pharmacy.System.Core.Interfaces.ISpecificationParams;
using Pharmacy.System.Core.Models;
using System.Linq.Expressions;
using System;

namespace Pharmacy.System.Services.Specifications
{
    public class ActiveIngredientSpecification : BaseSpecification<ActiveIngredient, int>
    {
        public ActiveIngredientSpecification(IActiveIngredientSpecParams specParams, bool isCount = false) : base(BuildCriteria(specParams))
        {
            if (!isCount)
            {
                ApplyPagination((specParams.PageIndex - 1) * specParams.PageSize, specParams.PageSize);
                AddOrderBy(x => x.Name);
            }
        }

        private static Expression<Func<ActiveIngredient, bool>> BuildCriteria(IActiveIngredientSpecParams specParams)
        {
            var name = specParams.Name?.ToLower();
            var description = specParams.Description?.ToLower();

            return x =>
                (string.IsNullOrEmpty(name) || x.Name.ToLower().Contains(name)) &&
                (string.IsNullOrEmpty(description) || x.Description.ToLower().Contains(description));
        }

    }
}
