using Microsoft.EntityFrameworkCore;
using Pharmacy.System.Core.Interfaces;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Infrastructure.DbContexts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pharmacy.System.Infrastructure.DataSeeders
{
    public class ManufacturerSeeder : IDataSeeder
    {
        private readonly AppDbContext _context;

        public int Order => 4;

        public ManufacturerSeeder(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task SeedAsync(CancellationToken token = default)
        {
            if (await _context.Manufacturers.AnyAsync())
                return;

            var manufacturers = new List<Manufacturer>
            {
                new() { Name = "EIPICO", Description = "Egyptian International Pharmaceutical Industries Co. - the largest pharmaceutical manufacturer in Egypt, 10th of Ramadan City" },
                new() { Name = "Amoun Pharmaceutical Company", Description = "One of Egypt's largest manufacturers of human and veterinary pharmaceuticals and food supplements" },
                new() { Name = "Pharco Pharmaceuticals", Description = "Major Egyptian manufacturer headquartered in Alexandria, known for hepatitis C treatments and affordable generics" },
                new() { Name = "EVA Pharma", Description = "Leading branded-generic pharmaceutical manufacturer in Egypt, the Middle East, and Africa" },
                new() { Name = "Adwia", Description = "Egyptian manufacturer of human and veterinary pharmaceuticals based in Obour City" },
                new() { Name = "Minapharm Pharmaceuticals", Description = "Egyptian pharmaceutical and biotechnology manufacturer" },
                new() { Name = "Global Napi Pharmaceuticals", Description = "Egyptian branded-generic manufacturer with EMA-approved facilities" },
                new() { Name = "Sigma Pharmaceutical Industries", Description = "Egyptian pharmaceutical manufacturer" },
                new() { Name = "Marcyrl Pharmaceutical Industries", Description = "Egyptian pharmaceutical manufacturer" },
                new() { Name = "Rameda Pharmaceuticals", Description = "Egyptian manufacturer of generic drugs, nutraceuticals, and veterinary products, 6th of October City" },
                new() { Name = "SEDICO Pharmaceutical Company", Description = "Egyptian manufacturer of human and veterinary pharmaceuticals, 6th of October City" },
                new() { Name = "Delta Pharma", Description = "Egyptian pharmaceutical manufacturer" },
                new() { Name = "Memphis Pharmaceutical and Chemical Industries", Description = "Long-established Egyptian pharmaceutical manufacturer (Holding Company for Pharmaceuticals group)" },
                new() { Name = "Nile Company for Pharmaceuticals and Chemical Industries", Description = "Long-established Egyptian pharmaceutical manufacturer (Holding Company for Pharmaceuticals group)" },
                new() { Name = "October Pharma", Description = "Egyptian pharmaceutical manufacturer" },
                new() { Name = "Kahira Pharmaceuticals and Chemical Industries", Description = "Long-established Egyptian pharmaceutical manufacturer (Holding Company for Pharmaceuticals group)" },
                new() { Name = "Middle East Company for Pharmaceutical Industries (MEPACO)", Description = "Long-established Egyptian pharmaceutical manufacturer (Holding Company for Pharmaceuticals group)" },
                new() { Name = "Arab Drug Company (ADCO)", Description = "Egyptian pharmaceutical manufacturer" },
                new() { Name = "Hi-Pharm", Description = "Egyptian manufacturer of pharmaceuticals and chemicals" },
                new() { Name = "Future Pharmaceutical Industries", Description = "Egyptian pharmaceutical manufacturer" },
                new() { Name = "Orchidia Pharmaceutical Industries", Description = "Egyptian manufacturer specializing in ophthalmic pharmaceutical products" },
                new() { Name = "Chemipharm Pharmaceutical Industries", Description = "Egyptian pharmaceutical manufacturer" },
                new() { Name = "COPAD Pharma", Description = "Egyptian pharmaceutical manufacturer" },
                new() { Name = "Dbk Pharma", Description = "Egyptian pharmaceutical manufacturer" },
                new() { Name = "AUG Pharma", Description = "Egyptian pharmaceutical manufacturer" },
                new() { Name = "Ateco Pharma Egypt", Description = "Egyptian pharmaceutical manufacturer" },
                new() { Name = "Al Andalous Pharmaceutical Industries", Description = "Egyptian pharmaceutical manufacturer" },
                new() { Name = "Amriya Pharmaceutical Industries", Description = "Long-established Egyptian pharmaceutical manufacturer, Alexandria (Holding Company for Pharmaceuticals group)" },
                new() { Name = "El Nasr Company for Pharmaceutical Chemicals", Description = "Long-established Egyptian pharmaceutical and chemicals manufacturer (Holding Company for Pharmaceuticals group)" },
                new() { Name = "Medical Union Pharmaceuticals (MUP)", Description = "Long-established Egyptian pharmaceutical manufacturer (Holding Company for Pharmaceuticals group)" },
                new() { Name = "Chemical Industries Development (CID)", Description = "Egyptian chemicals and pharmaceutical manufacturer (Holding Company for Pharmaceuticals group)" },
                new() { Name = "Zeta Pharma", Description = "Egyptian pharmaceutical manufacturer" },
                new() { Name = "MACRO Group Pharmaceuticals", Description = "Egyptian pharmaceutical manufacturer" },
                new() { Name = "Grifols Egypt for Plasma Derivatives (GEPD)", Description = "Egypt-based plasma derivatives manufacturing facility" },
                new() { Name = "Utopia Pharmaceuticals", Description = "Egyptian pharmaceutical manufacturer" },
                new() { Name = "BioMED Egypt", Description = "Egyptian pharmaceutical manufacturer" },
                new() { Name = "Averroes Pharma", Description = "Egyptian pharmaceutical manufacturer specializing in blood health products" },
                new() { Name = "MDI Pharma", Description = "Cairo-based Egyptian manufacturer of innovative healthcare products" },
                new() { Name = "Pharaonia Pharmaceuticals", Description = "Egyptian pharmaceutical manufacturer with a portfolio of over 270 brands" },
                new() { Name = "Alexandria Company for Pharmaceuticals and Chemical Industries", Description = "Long-established Egyptian pharmaceutical manufacturer, Alexandria (Holding Company for Pharmaceuticals group)" },
                new() { Name = "Mash Premiere (Pharmaoverseas)", Description = "Egyptian pharmaceutical manufacturer and exporter" },
                new() { Name = "VACSERA", Description = "Egyptian Company for Producing Vaccines, Sera & Drugs - state-owned vaccine and biologics manufacturer" },
                new() { Name = "Sanofi-Aventis Egypt", Description = "Multinational manufacturer with local production in Egypt" },
                new() { Name = "GlaxoSmithKline Egypt", Description = "Multinational manufacturer with local production in Egypt" },
                new() { Name = "Novartis Pharma Egypt", Description = "Multinational manufacturer with local production in Egypt" },
                new() { Name = "Egypt Otsuka Pharmaceutical", Description = "Egyptian subsidiary of Japan's Otsuka Pharmaceutical, local manufacturing" },
                new() { Name = "Abbott Laboratories Egypt", Description = "Multinational manufacturer with local production in Egypt" },
                new() { Name = "AstraZeneca Egypt", Description = "Multinational manufacturer with local production in Egypt" },
                new() { Name = "Hikma Pharmaceuticals - Egypt", Description = "Multinational manufacturer with local production in Egypt" },
            };

            await _context.Manufacturers.AddRangeAsync(manufacturers);
            await _context.SaveChangesAsync();
        }
    }
}