using Pharmacy.System.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.System.Core.Models
{
    public class ProductActiveIngredient : BaseModel<int>
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }


        [ForeignKey("ActiveIngredient")]
        public int ActiveIngredientId { get; set; }
        public ActiveIngredient ActiveIngredient { get; set; }


        public float Quantity { get; set; }
        public ActiveIngredientUnit Unit { get; set; }
    }
}
