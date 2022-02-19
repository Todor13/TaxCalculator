using System;

namespace TaxCalculator.Core.Contracts
{
    public interface ITaxPayer
    {
        string FullName { get; set; }
        string SSN { get; set; }
        DateTime DateOfBirth { get; set; }
        decimal GrossIncome { get; set; }
    }
}