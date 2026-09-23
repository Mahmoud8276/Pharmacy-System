
namespace Pharmacy.System.Core.Models
{
    public class PackagingUnit : BaseModel<int>
    {
        public string Name { get; set; }
        public string? Symbol { get; set; }
    }
}
