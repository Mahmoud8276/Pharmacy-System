using Microsoft.EntityFrameworkCore;
using Pharmacy.System.Core.Interfaces;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Infrastructure.DbContexts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pharmacy.System.Infrastructure.DataSeeders
{
    public class PackagingUnitDataSeeder : IDataSeeder
    {
        private readonly AppDbContext _context;
        public int Order => 6;

        public PackagingUnitDataSeeder(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task SeedAsync(CancellationToken token = default)
        {
            if (await _context.PackagingUnits.AnyAsync(token))
                return;

            var packagingUnits = new List<PackagingUnit>
            {
                new() { Name = "Strip",   Symbol = "strip" },
                new() { Name = "Blister", Symbol = "blstr" },
                new() { Name = "Box",     Symbol = "box" },
                new() { Name = "Carton",  Symbol = "ctn" },
                new() { Name = "Bottle",  Symbol = "btl" },
                new() { Name = "Jar",     Symbol = "jar" },
                new() { Name = "Tube",    Symbol = "tube" },
                new() { Name = "Tray",    Symbol = "tray" },
                new() { Name = "Pouch",   Symbol = "pouch" },
                new() { Name = "Pack",    Symbol = "pack" },
                new() { Name = "Case",    Symbol = "case" },
            };

            await _context.PackagingUnits.AddRangeAsync(packagingUnits, token);
            await _context.SaveChangesAsync(token);
        }
    }
}