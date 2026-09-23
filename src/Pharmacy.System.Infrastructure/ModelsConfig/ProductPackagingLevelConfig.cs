using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.System.Core.Models;

namespace Pharmacy.System.Infrastructure.ModelsConfig
{
    public class ProductPackagingLevelConfig : IEntityTypeConfiguration<ProductPackagingLevel>
    {
        public void Configure(EntityTypeBuilder<ProductPackagingLevel> builder)
        {

        }
    }
}
