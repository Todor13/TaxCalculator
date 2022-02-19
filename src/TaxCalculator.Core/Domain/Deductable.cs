using TaxCalculator.Core.Contracts;

namespace TaxCalculator.Core.Domain
{
    public class Deductable : IEntity, INamedEntity, IDeductable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int TaxPayerId { get; set; }
        public TaxPayer TaxPayer { get; set; }
    }
}