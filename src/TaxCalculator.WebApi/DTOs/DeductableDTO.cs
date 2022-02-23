using System;
using System.ComponentModel.DataAnnotations;
using TaxCalculator.Core.Contracts;

namespace TaxCalculator.WebApi.DTOs
{
    public class DeductableDTO : IDeductable
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, Double.MaxValue)]
        public decimal Amount { get; set; }

        public DeductableDTO()
        {      
        }
    }
}