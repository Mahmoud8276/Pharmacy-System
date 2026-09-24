using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.System.Core.Models;

namespace Pharmacy.System.Infrastructure.ModelsConfig
{
    public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasMany<Product>()
                   .WithOne(x => x.Category)
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
                   
        }
    }
}
