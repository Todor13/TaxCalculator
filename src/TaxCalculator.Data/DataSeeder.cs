using System.Collections.Generic;
using System.Linq;
using TaxCalculator.Core.Domain;

namespace TaxCalculator.Data
{
    public class DataSeeder
    {
        public static void SeedTaxRules(ApplicationDbContext context)
        {
            if (!context.TaxRules.Any())
            {
                var taxRules = new List<TaxRule>() {
                    new TaxRule() {
                        Name = "Income Tax",
                        Percent = 10,
                        MinThreshold = 1000,
                        MaxThreshold = null
                    },
                    new TaxRule() {
                        Name = "Social Tax",
                        Percent = 15,
                        MinThreshold = 1000,
                        MaxThreshold = 3000
                    }
                 };

                context.AddRange(taxRules);
                context.SaveChanges();
            }
        }

        public static void SeedDeductableRules(ApplicationDbContext context)
        {
            if (!context.DeductionRules.Any())
            {
                var deductionRules = new List<DeductionRule>() {
                    new DeductionRule() {
                        Name = "CharitySpent",
                        MaxPercentThreshold = 10
                    }
                 };

                context.AddRange(deductionRules);
                context.SaveChanges();
            }
        }
    }
}
