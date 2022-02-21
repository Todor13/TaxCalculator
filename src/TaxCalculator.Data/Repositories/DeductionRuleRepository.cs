using TaxCalculator.Core.Domain;
using TaxCalculator.Data.Repositories.Contracts;

namespace TaxCalculator.Data.Repositories
{
    public class DeductionRuleRepository : GenericRepository<DeductionRule>, IDeductionRuleRepository
    {
        public DeductionRuleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}