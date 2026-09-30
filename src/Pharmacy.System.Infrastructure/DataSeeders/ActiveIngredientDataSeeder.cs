using Microsoft.EntityFrameworkCore;
using Pharmacy.System.Core.Interfaces;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Infrastructure.DbContexts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pharmacy.System.Infrastructure.DataSeeders
{
    public class ActiveIngredientDataSeeder : IDataSeeder
    {
        private readonly AppDbContext _context;
        private readonly List<ActiveIngredient> _activeIngredients = new List<ActiveIngredient>
        {
            new() { Name = "Paracetamol", Description = "Analgesic and antipyretic." },
            new() { Name = "Ibuprofen", Description = "Nonsteroidal anti-inflammatory drug (NSAID)." },
            new() { Name = "Naproxen", Description = "Nonsteroidal anti-inflammatory drug (NSAID)." },

            new() { Name = "Amoxicillin", Description = "Penicillin-class antibiotic." },
            new() { Name = "Azithromycin", Description = "Macrolide antibiotic." },
            new() { Name = "Cefixime", Description = "Third-generation cephalosporin antibiotic." },
            new() { Name = "Cefuroxime", Description = "Second-generation cephalosporin antibiotic." },
            new() { Name = "Metronidazole", Description = "Antimicrobial and antiprotozoal agent." },

            new() { Name = "Omeprazole", Description = "Proton pump inhibitor." },
            new() { Name = "Esomeprazole", Description = "Proton pump inhibitor." },
            new() { Name = "Pantoprazole", Description = "Proton pump inhibitor." },

            new() { Name = "Metformin", Description = "Biguanide antidiabetic medication." },
            new() { Name = "Glimepiride", Description = "Sulfonylurea antidiabetic medication." },

            new() { Name = "Amlodipine", Description = "Calcium channel blocker." },
            new() { Name = "Losartan", Description = "Angiotensin II receptor blocker (ARB)." },
            new() { Name = "Valsartan", Description = "Angiotensin II receptor blocker (ARB)." },
            new() { Name = "Bisoprolol", Description = "Beta-1 selective adrenergic blocker." },

            new() { Name = "Atorvastatin", Description = "HMG-CoA reductase inhibitor (statin)." },
            new() { Name = "Rosuvastatin", Description = "HMG-CoA reductase inhibitor (statin)." },

            new() { Name = "Loratadine", Description = "Second-generation antihistamine." },
            new() { Name = "Cetirizine", Description = "Second-generation antihistamine." },
            new() { Name = "Levocetirizine", Description = "Second-generation antihistamine." },

            new() { Name = "Salbutamol", Description = "Short-acting beta-2 adrenergic agonist." },
            new() { Name = "Montelukast", Description = "Leukotriene receptor antagonist." },

            new() { Name = "Diclofenac", Description = "Nonsteroidal anti-inflammatory drug (NSAID)." },
            new() { Name = "Ketorolac", Description = "Nonsteroidal anti-inflammatory drug (NSAID)." },

            new() { Name = "Dexamethasone", Description = "Corticosteroid." },
            new() { Name = "Prednisolone", Description = "Corticosteroid." },

            new() { Name = "Fluconazole", Description = "Triazole antifungal." },
            new() { Name = "Acyclovir", Description = "Antiviral medication." }
        };

        public int Order => 5;

        public ActiveIngredientDataSeeder(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync(CancellationToken token = default)
        {
            if (await _context.ActiveIngredients.AnyAsync())
                return;

            await _context.ActiveIngredients.AddRangeAsync(_activeIngredients, token);
            await _context.SaveChangesAsync(token);
        }
    }
}