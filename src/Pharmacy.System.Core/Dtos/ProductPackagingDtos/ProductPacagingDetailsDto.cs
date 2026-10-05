
namespace Pharmacy.System.Core.Dtos.ProductPackagingDtos
{
    public class ProductPacagingDetailsDto
    {
        public int Id { get; set; }
        public int PackagingUnitId { get; set; }
        public string PackagingUnitName { get; set; }
        public string? ChildPackagingUnitName { get; set; }
        public decimal ChildPackagingUnitQuantity { get; set; }
    }
}
