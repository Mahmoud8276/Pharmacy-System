using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.System.Core.Models;

namespace Pharmacy.System.Infrastructure.ModelsConfig
{
    public class ProductActiveIngredientConfig : IEntityTypeConfiguration<ProductActiveIngredient>
    {
        public void Configure(EntityTypeBuilder<ProductActiveIngredient> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x =>
            new
            {
                x.ProductId,
                x.ActiveIngredientId
            }).IsUnique();
        }
    }
}
