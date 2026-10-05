using System.ComponentModel.DataAnnotations;

namespace Pharmacy.System.Core.Dtos.ProductPackagingDtos
{
    public class UpdateProductPackagingDto
    {
        [Required(ErrorMessage = "Child Unit Quantity Is Required!")]
        [Range(1, int.MaxValue, ErrorMessage = "Child Quantity Must Be Larger Than Or Equal 1")]
        public int Quantity { get; set; }
    }
}
