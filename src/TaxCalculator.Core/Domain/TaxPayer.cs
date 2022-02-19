using System;
using System.Collections.Generic;
using TaxCalculator.Core.Contracts;

namespace TaxCalculator.Core.Domain
{
    public class TaxPayer : IEntity, ITaxPayer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string SSN { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal GrossIncome { get; set; }
        public IEnumerable<Deductable> Deductables { get; set; }
    }
}