using System.Collections.Generic;
using TaxCalculator.Core.Contracts;

namespace TaxCalculator.Core.Models
{
    public class TaxesModel : ITaxes
    {
        public decimal GrossIncome { get; set; }
        public decimal TotalTax { get; set; }
        public decimal NetIncome { get; set; }
        public decimal TotalDeductions { get; set; }
        public IEnumerable<ITaxResult> TaxesApplied { get; set; }

        public TaxesModel(decimal grossIncome, decimal totalTax, decimal netIncome, decimal totalDeductions, IEnumerable<ITaxResult> taxesApplied)
        {
            this.GrossIncome = grossIncome;
            this.TotalTax = totalTax;
            this.NetIncome = netIncome;
            this.TotalDeductions = totalDeductions;
            this.TaxesApplied = taxesApplied;
        }
    }
}