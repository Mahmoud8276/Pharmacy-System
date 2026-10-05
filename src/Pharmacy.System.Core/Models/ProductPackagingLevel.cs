using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.System.Core.Models
{
    public class ProductPackagingLevel : BaseModel<int>
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("PackagingUnit")]
        public int PackagingUnitId {  get; set; }
        public PackagingUnit PackagingUnit { get; set; }

        [ForeignKey("Parent")]
        public int? ParentId { get; set; } = null;
        public ProductPackagingLevel Parent {  get; set; }

        public decimal QuantityOfChildPackage { get; set; }
        public decimal QuantityOfBaseUnit { get; set; }
    }
}
