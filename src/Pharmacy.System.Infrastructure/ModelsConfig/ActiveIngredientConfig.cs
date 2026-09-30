using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.System.Core.Models;

namespace Pharmacy.System.Infrastructure.ModelsConfig
{
    public class ActiveIngredientConfig : IEntityTypeConfiguration<ActiveIngredient>
    {
        public void Configure(EntityTypeBuilder<ActiveIngredient> builder)
        {
            builder.HasMany(x => x.ProductActiveIngredients)
                   .WithOne(x => x.ActiveIngredient)
                   .HasForeignKey(x => x.ActiveIngredientId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
