using TaxCalculator.Core.Contracts;

namespace TaxCalculator.Core.Models
{
    public class TaxResultModel : ITaxResult
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }

        public TaxResultModel(string name, decimal amount)
        {
            this.Name = name;
            this.Amount = amount;
        }
    }
}