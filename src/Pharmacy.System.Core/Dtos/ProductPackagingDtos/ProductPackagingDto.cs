using System.ComponentModel.DataAnnotations;

namespace Pharmacy.System.Core.Dtos.ProductPackagingDtos
{
    public class ProductPackagingDto
    {
        [Required(ErrorMessage = "Packaging Unit Id Is Required!")]
        public int PackagingUnitId { get; set; }
        public int? ChildUnitId { get; set; }

        [Required(ErrorMessage = "Quantity Of The Child Package Is Required!")]
        [Range(1, int.MaxValue, ErrorMessage = "Child Quantity Must Be Larger Than Or Equal 1")]
        public int Quantity { get; set; }
    }
}
