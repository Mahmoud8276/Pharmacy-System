using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.System.Core.Models
{
    public class ProductForm : BaseModel<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        [ForeignKey("BaseUnit")]
        public int BaseUnitId { get; set; }
        public BaseUnit BaseUnit { get; set; }
    }
}
