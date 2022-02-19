using TaxCalculator.Core.Contracts;

namespace TaxCalculator.Core.Domain
{
    public class DeductionRule : IEntity, INamedEntity, IDeductionRule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MaxPercentThreshold { get; set; }
    }
}