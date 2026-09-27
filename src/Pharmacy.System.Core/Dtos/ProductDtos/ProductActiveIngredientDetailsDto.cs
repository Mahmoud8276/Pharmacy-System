using Pharmacy.System.Core.Enums;

namespace Pharmacy.System.Core.Dtos.ProductDtos
{
    public class ProductActiveIngredientDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Quantity { get; set; }
        public ActiveIngredientUnit Unit { get; set; }
    }
}
