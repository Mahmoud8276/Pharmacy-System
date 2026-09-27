
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.System.Core.Dtos.ProductFormDtos
{
    public class ProductFormDto
    {
        [Required(ErrorMessage = "Product Form Name is Required!")]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "Base Unit ID is Required!")]
        public int BaseUnitId { get; set; }

    }
}
