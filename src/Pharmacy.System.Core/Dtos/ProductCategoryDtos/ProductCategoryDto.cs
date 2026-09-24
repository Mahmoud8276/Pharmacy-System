using System.ComponentModel.DataAnnotations;

namespace Pharmacy.System.Core.Dtos.ProductCategoryDtos
{
    public class ProductCategoryDto
    {
        [Required(ErrorMessage = "Category Name is Required!")]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
