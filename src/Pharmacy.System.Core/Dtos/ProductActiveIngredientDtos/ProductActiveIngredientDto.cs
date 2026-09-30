using Pharmacy.System.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.System.Core.Dtos.ProductActiveIngredientDtos
{
    public class ProductActiveIngredientDto
    {
        [Required(ErrorMessage = "Active Ingredient Quantity Is Required!")]
        public float Quantity { get; set; }

        [Required(ErrorMessage = "Active Ingredient Quantity Unit Is Required!")]
        public ActiveIngredientUnit Unit { get; set; }
    }
}
