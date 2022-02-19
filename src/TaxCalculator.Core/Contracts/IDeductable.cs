namespace TaxCalculator.Core.Contracts
{
    public interface IDeductable
    {
        string Name { get; set; }
        decimal Amount { get; set; }
    }
}