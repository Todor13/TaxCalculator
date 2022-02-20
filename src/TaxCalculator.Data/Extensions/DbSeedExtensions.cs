using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TaxCalculator.Data.Extensions
{
    public static class DbSeedExtensions
    {
        public static IHost SeedDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    context.Database.EnsureCreated();

                    DataSeeder.SeedTaxRules(context);
                    DataSeeder.SeedDeductableRules(context);
                }
            }
            return host;
        }
    }
}
