
namespace Pharmacy.System.Core.Models
{
    public class Manufacturer : BaseModel<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
