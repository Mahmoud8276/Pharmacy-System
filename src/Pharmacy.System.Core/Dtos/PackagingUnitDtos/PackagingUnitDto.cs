using System.ComponentModel.DataAnnotations;

namespace Pharmacy.System.Core.Dtos.PackagingUnitDtos
{
    public class PackagingUnitDto
    {
        [Required(ErrorMessage = "Packaging Unit Is Required!")]
        public string Name { get; set; }
        public string? Symbol { get; set; }
    }
}
