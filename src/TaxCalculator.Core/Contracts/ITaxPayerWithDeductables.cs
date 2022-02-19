using System.Collections.Generic;

namespace TaxCalculator.Core.Contracts
{
    public interface ITaxPayerWithDeductables : ITaxPayer
    {
        IEnumerable<IDeductable> Deductables { get; set; }
    }
}