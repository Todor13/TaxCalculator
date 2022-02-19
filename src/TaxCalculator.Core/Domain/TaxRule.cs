using TaxCalculator.Core.Contracts;

namespace TaxCalculator.Core.Domain
{
    public class TaxRule : IEntity, INamedEntity, ITaxRule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? MaxThreshold { get; set; }
        public decimal? MinThreshold { get; set; }
        public decimal Percent { get; set; }
    }
}