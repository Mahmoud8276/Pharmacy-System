using Pharmacy.System.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Pharmacy.System.Infrastructure.ModelsConfig
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.RegistrationTimestamp)
                   .HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }
}
