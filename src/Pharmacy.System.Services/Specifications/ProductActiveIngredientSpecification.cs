using Pharmacy.System.Core.Models;

namespace Pharmacy.System.Services.Specifications
{
    public class ProductActiveIngredientSpecification : BaseSpecification<ProductActiveIngredient, int>
    {
        /// <summary>
        /// Builds a specification for retrieving every active-ingredient association for a product,
        /// with each association's <see cref="ProductActiveIngredient.ActiveIngredient"/> details included.
        /// </summary>
        /// <param name="productId">The id of the product whose active-ingredient associations to retrieve.</param>
        public ProductActiveIngredientSpecification(int productId)
            : base(x => x.ProductId == productId)
        {
            AddInclude(x => x.ActiveIngredient);
        }

        /// <summary>
        /// Builds a specification for retrieving a single active-ingredient association for a product,
        /// with the <see cref="ProductActiveIngredient.ActiveIngredient"/> details included.
        /// </summary>
        /// <param name="productId">The id of the product the association belongs to.</param>
        /// <param name="activeIngredientId">The id of the active ingredient the association is for.</param>
        public ProductActiveIngredientSpecification(int productId, int activeIngredientId)
            : base(x => x.ProductId == productId && x.ActiveIngredientId == activeIngredientId)
        {
            AddInclude(x => x.ActiveIngredient);
        }
    }
}