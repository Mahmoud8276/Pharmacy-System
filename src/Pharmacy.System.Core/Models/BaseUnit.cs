using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.System.Core.Models
{
    public class BaseUnit : BaseModel<int>
    {
        public string Name { get; set; }
        public string? Symbol { get; set; }
        public decimal ConversionFactor { get; set; }
        public bool IsImmutable { get; set; }

        [ForeignKey("UnitFamily")]
        public int? UnitFamilyId { get; set; }
        public UnitFamily? UnitFamily { get; set; }

        [ForeignKey("CanoncialUnit")]
        public int? CanoncialUnitId { get; set; }
        public BaseUnit CanoncialUnit { get; set; }
    }
}
