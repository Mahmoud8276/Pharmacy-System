
namespace Pharmacy.System.Core.Dtos.ProductDtos
{
    public class ProductPackagingLevelDetailsDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string PackagingUnitName { get; set; }
        public string ChildUnitName { get; set; }
        public decimal ChildUnitQuantity { get; set; }

    }
}
