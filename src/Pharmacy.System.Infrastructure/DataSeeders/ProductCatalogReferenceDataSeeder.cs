using Microsoft.EntityFrameworkCore;
using Pharmacy.System.Core.Interfaces;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Infrastructure.DbContexts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pharmacy.System.Infrastructure.DataSeeders
{
    public class ProductCatalogReferenceDataSeeder : IDataSeeder
    {
        private readonly AppDbContext _context;
        public int Order => 3;

        public ProductCatalogReferenceDataSeeder(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task SeedAsync(CancellationToken token = default)
        {
            await SeedUnitFamiliesAsync();
            await SeedBaseUnitsAsync();
            await SeedProductFormsAsync();
            await SeedProductCategoriesAsync();
        }

        private async Task SeedUnitFamiliesAsync()
        {
            if (await _context.UnitFamilies.AnyAsync())
                return;

            var families = new List<UnitFamily>
            {
                new() { Name = "Volume" },
                new() { Name = "Mass" },
            };

            await _context.UnitFamilies.AddRangeAsync(families);
            await _context.SaveChangesAsync();
        }

        private async Task SeedBaseUnitsAsync()
        {
            if (await _context.BaseUnits.AnyAsync())
                return;

            var familyIds = await _context.UnitFamilies.ToDictionaryAsync(f => f.Name, f => f.Id);


            var baseUnits = new List<BaseUnit>
            {
                new() { Name = "Tablet",              Symbol = "tab",   ConversionFactor = 1, IsImmutable = true, UnitFamilyId = null },
                new() { Name = "Capsule",              Symbol = "cap",   ConversionFactor = 1, IsImmutable = true, UnitFamilyId = null },
                new() { Name = "Milliliter",           Symbol = "ml",    ConversionFactor = 1, IsImmutable = true, UnitFamilyId = familyIds["Volume"] },
                new() { Name = "Gram",                 Symbol = "g",     ConversionFactor = 1, IsImmutable = true, UnitFamilyId = familyIds["Mass"] },
                new() { Name = "Suppository",          Symbol = "supp",  ConversionFactor = 1, IsImmutable = true, UnitFamilyId = null },
                new() { Name = "Ampoule",               Symbol = "amp",   ConversionFactor = 1, IsImmutable = true, UnitFamilyId = null },
                new() { Name = "Vial",                  Symbol = "vial",  ConversionFactor = 1, IsImmutable = true, UnitFamilyId = null },
                new() { Name = "Sachet",                Symbol = "sach",  ConversionFactor = 1, IsImmutable = true, UnitFamilyId = null },
                new() { Name = "Patch",                 Symbol = "patch", ConversionFactor = 1, IsImmutable = true, UnitFamilyId = null },
                new() { Name = "Puff",                  Symbol = "puff",  ConversionFactor = 1, IsImmutable = true, UnitFamilyId = null },
                new() { Name = "Drop",                  Symbol = "drop",  ConversionFactor = 1, IsImmutable = true, UnitFamilyId = null },
                new() { Name = "International Unit",    Symbol = "IU",    ConversionFactor = 1, IsImmutable = true, UnitFamilyId = null },
            };

            await _context.BaseUnits.AddRangeAsync(baseUnits);
            await _context.SaveChangesAsync();
        }

        private async Task SeedProductFormsAsync()
        {
            if (await _context.ProductForms.AnyAsync())
                return;

            var baseUnitIds = await _context.BaseUnits.ToDictionaryAsync(u => u.Name, u => u.Id);

            var productForms = new List<ProductForm>
            {
                new() { Name = "Tablet",                BaseUnitId = baseUnitIds["Tablet"] },
                new() { Name = "Chewable Tablet",        BaseUnitId = baseUnitIds["Tablet"] },
                new() { Name = "Effervescent Tablet",    BaseUnitId = baseUnitIds["Tablet"] },
                new() { Name = "Lozenge",                BaseUnitId = baseUnitIds["Tablet"] },
                new() { Name = "Capsule",                BaseUnitId = baseUnitIds["Capsule"] },
                new() { Name = "Syrup",                  BaseUnitId = baseUnitIds["Milliliter"] },
                new() { Name = "Suspension",             BaseUnitId = baseUnitIds["Milliliter"] },
                new() { Name = "Oral Solution",          BaseUnitId = baseUnitIds["Milliliter"] },
                new() { Name = "Eye Drops",              BaseUnitId = baseUnitIds["Milliliter"] },
                new() { Name = "Ear Drops",              BaseUnitId = baseUnitIds["Milliliter"] },
                new() { Name = "Injection (Ampoule)",    BaseUnitId = baseUnitIds["Ampoule"] },
                new() { Name = "Injection (Vial)",       BaseUnitId = baseUnitIds["Vial"] },
                new() { Name = "Cream",                  BaseUnitId = baseUnitIds["Gram"] },
                new() { Name = "Ointment",               BaseUnitId = baseUnitIds["Gram"] },
                new() { Name = "Gel",                    BaseUnitId = baseUnitIds["Gram"] },
                new() { Name = "Suppository",            BaseUnitId = baseUnitIds["Suppository"] },
                new() { Name = "Nasal Spray",            BaseUnitId = baseUnitIds["Puff"] },
                new() { Name = "Inhaler",                BaseUnitId = baseUnitIds["Puff"] },
                new() { Name = "Powder / Sachet",        BaseUnitId = baseUnitIds["Sachet"] },
                new() { Name = "Transdermal Patch",      BaseUnitId = baseUnitIds["Patch"] },
            };

            await _context.ProductForms.AddRangeAsync(productForms);
            await _context.SaveChangesAsync();
        }

        private async Task SeedProductCategoriesAsync()
        {
            if (await _context.ProductCategories.AnyAsync())
                return;

            var categories = new List<ProductCategory>
            {
                new() { Name = "Analgesics & Antipyretics",              Description = "Pain relief and fever reduction" },
                new() { Name = "Antibiotics",                            Description = "Bacterial infection treatment" },
                new() { Name = "Antivirals",                             Description = "Viral infection treatment" },
                new() { Name = "Antifungals",                            Description = "Fungal infection treatment" },
                new() { Name = "Antihistamines & Allergy",               Description = "Allergy relief and antihistamines" },
                new() { Name = "Cardiovascular",                         Description = "Heart and blood pressure medications" },
                new() { Name = "Diabetes Care",                          Description = "Blood sugar management" },
                new() { Name = "Gastrointestinal",                       Description = "Digestive system treatment" },
                new() { Name = "Respiratory",                            Description = "Asthma, COPD, and respiratory conditions" },
                new() { Name = "Dermatological",                        Description = "Skin condition treatment" },
                new() { Name = "Vitamins & Supplements",                 Description = "Nutritional supplementation" },
                new() { Name = "Ophthalmic",                             Description = "Eye care products" },
                new() { Name = "ENT (Ear, Nose & Throat)",               Description = "Ear, nose, and throat treatment" },
                new() { Name = "Hormonal & Endocrine",                   Description = "Hormone-related treatment" },
                new() { Name = "Central Nervous System",                 Description = "Neurological conditions" },
                new() { Name = "Psychiatric",                            Description = "Mental health medications" },
                new() { Name = "Musculoskeletal & Anti-inflammatory",    Description = "Joint, muscle, and inflammation treatment" },
                new() { Name = "Oncology",                               Description = "Cancer treatment" },
                new() { Name = "Contraceptives & Reproductive Health",   Description = "Family planning and reproductive care" },
                new() { Name = "Vaccines & Immunizations",               Description = "Preventive immunization products" },
                new() { Name = "Anesthetics",                            Description = "Local and general anesthesia products" },
                new() { Name = "Anticoagulants & Blood",                 Description = "Blood thinning and hematological treatment" },
                new() { Name = "Urology",                                Description = "Urinary system treatment" },
                new() { Name = "Pediatric Care",                         Description = "Medications formulated for children" },
                new() { Name = "First Aid & Wound Care",                 Description = "Wound dressing and first-aid supplies" },
                new() { Name = "Personal Care & Hygiene",                Description = "General hygiene and personal care products" },
                new() { Name = "Baby Care",                              Description = "Infant and baby care products" },
            };

            await _context.ProductCategories.AddRangeAsync(categories);
            await _context.SaveChangesAsync();
        }
    }
}