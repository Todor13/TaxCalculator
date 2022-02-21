using Microsoft.EntityFrameworkCore;
using TaxCalculator.Core.Domain;
using TaxCalculator.Data.Repositories.Contracts;

namespace TaxCalculator.Data.Repositories
{
    public class TaxRuleRepository : GenericRepository<TaxRule>, ITaxRuleRepository
    {
        public TaxRuleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}