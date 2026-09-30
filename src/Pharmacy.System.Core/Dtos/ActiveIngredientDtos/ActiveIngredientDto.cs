
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.System.Core.Dtos.ActiveIngredientDtos
{
    public class ActiveIngredientDto
    {
        [Required(ErrorMessage = "Active Ingredient Name Is Required")]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
