using System.Collections.Generic;

namespace Pharmacy.System.Core.Models
{
    public class ActiveIngredient : BaseModel<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<ProductActiveIngredient> ProductActiveIngredients { get; set; } = new HashSet<ProductActiveIngredient>();
    }
}
