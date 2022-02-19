namespace TaxCalculator.Core.Contracts
{
    public interface ITaxResult
    {
        string Name { get; set; }
        decimal Amount { get; set; }
    }
}