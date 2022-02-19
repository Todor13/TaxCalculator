namespace TaxCalculator.Core.Contracts
{
    public interface ITaxRule : INamedEntity
    {
        decimal? MaxThreshold { get; set; }
        decimal? MinThreshold { get; set; }
        decimal Percent { get; set; }
    }
}