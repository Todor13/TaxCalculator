using System.Collections.Generic;

namespace TaxCalculator.Core.Contracts
{
    public interface ITaxes
    {
        decimal GrossIncome { get; set; }
        decimal TotalTax { get; set; }
        decimal NetIncome { get; set; }
        decimal TotalDeductions { get; set; }
        IEnumerable<ITaxResult> TaxesApplied { get; set; }
    }
}