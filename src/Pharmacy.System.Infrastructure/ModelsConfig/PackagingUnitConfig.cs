using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.System.Core.Models;

namespace Pharmacy.System.Infrastructure.ModelsConfig
{
    public class PackagingUnitConfig : IEntityTypeConfiguration<PackagingUnit>
    {
        public void Configure(EntityTypeBuilder<PackagingUnit> builder)
        {
            builder.HasMany<ProductPackagingLevel>()
                   .WithOne(x => x.PackagingUnit)
                   .HasForeignKey(x => x.PackagingUnitId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
