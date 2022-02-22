using System.Collections.Generic;
using TaxCalculator.Core.Contracts;

namespace TaxCalculator.Services
{
    public interface ITaxCalculationService
    {
        ITaxes CalculateTax(ITaxPayerWithDeductables taxPayer, IEnumerable<ITaxRule> taxRules, IEnumerable<IDeductionRule> deductionRules);
    }
}