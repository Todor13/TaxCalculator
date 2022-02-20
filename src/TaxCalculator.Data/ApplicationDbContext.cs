using Microsoft.EntityFrameworkCore;
using TaxCalculator.Core.Domain;

namespace TaxCalculator.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaxRule> TaxRules { get; set; }
        public DbSet<DeductionRule> DeductionRules { get; set; }
        public DbSet<TaxPayer> TaxPayers { get; set; }
        public DbSet<Deductable> Deductables { get; set; }
    }
}
