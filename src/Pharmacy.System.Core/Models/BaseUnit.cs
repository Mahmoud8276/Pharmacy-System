
namespace Pharmacy.System.Core.Models
{
    public class BaseUnit : BaseModel<int>
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal ConversionFactor { get; set; }
        public bool IsImmutable { get; set; }
    }
}
