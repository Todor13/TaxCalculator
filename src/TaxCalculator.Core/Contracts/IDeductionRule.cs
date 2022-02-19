namespace TaxCalculator.Core.Contracts
{
    public interface IDeductionRule : INamedEntity
    {
        decimal MaxPercentThreshold { get; set; }
    }
}