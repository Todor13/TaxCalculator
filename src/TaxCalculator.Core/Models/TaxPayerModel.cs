using System;
using System.Collections.Generic;
using TaxCalculator.Core.Contracts;

namespace TaxCalculator.Core.Models
{
    public class TaxPayerModel : ITaxPayerWithDeductables
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string SSN { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal GrossIncome { get; set; }
        public IEnumerable<IDeductable> Deductables { get; set; }

        public TaxPayerModel()
        {
        }

        public TaxPayerModel(string fullName, string ssn, decimal grossIncome, IEnumerable<IDeductable> deductables)
        {
            this.FullName = fullName;
            this.SSN = ssn;
            this.GrossIncome = grossIncome;
            this.Deductables = deductables;
        }
    }
}