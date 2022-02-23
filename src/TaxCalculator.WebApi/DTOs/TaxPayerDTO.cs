using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaxCalculator.Core.Contracts;

namespace TaxCalculator.WebApi.DTOs
{
    public class TaxPayerDTO : ITaxPayer
    {        
        [Required]
        [RegularExpression(@"^([a-zA-Z-!$%^&*()_+|~=`{}\[\]:;'<>?,.\/]+)\s+([a-zA-Z -!$%^&*()_+|~=`{}\[\]:;'<>?,.\/]{2,})$", ErrorMessage = "Full Name should consist of two, or more words separeted by whitespace!")]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^\d{5,10}$", ErrorMessage = "SSN number should consist of 5 to 10 digits number, unique per tax payer!")]
        public string SSN { get; set; }
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Range(0, Double.MaxValue)]
        public decimal GrossIncome { get; set; }
        public IEnumerable<DeductableDTO> Deductables { get; set; }

        public TaxPayerDTO() 
        { 
        }

        public TaxPayerDTO(string fullName, string ssn, decimal grossIncome, IEnumerable<DeductableDTO> deductables)
        {
            this.FullName = fullName;
            this.SSN = ssn;
            this.GrossIncome = grossIncome;
            this.Deductables = deductables;
        }
    }
}