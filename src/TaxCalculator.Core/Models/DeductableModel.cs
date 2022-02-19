using TaxCalculator.Core.Contracts;

namespace TaxCalculator.Core.Models
{
    public class DeductableModel : IDeductable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}