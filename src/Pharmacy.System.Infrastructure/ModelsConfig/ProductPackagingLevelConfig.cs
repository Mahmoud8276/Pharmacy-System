using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.System.Core.Models;

namespace Pharmacy.System.Infrastructure.ModelsConfig
{
    public class ProductPackagingLevelConfig : IEntityTypeConfiguration<ProductPackagingLevel>
    {
        public void Configure(EntityTypeBuilder<ProductPackagingLevel> builder)
        {
            builder.HasIndex(p => new { p.ProductId, p.PackagingUnitId }).IsUnique();

            builder.HasOne(x => x.Parent)
                   .WithMany()
                   .HasForeignKey(x => x.ParentId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasCheckConstraint(
                "CK_ProductPackagingLevels_QuantityOfChildPackage",
                "[QuantityOfChildPackage] >= 1");
        }
    }
}
