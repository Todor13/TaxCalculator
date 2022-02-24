using System.Collections.Generic;
using TaxCalculator.Core.Domain;
using TaxCalculator.Core.Models;
using Xunit;

namespace TaxCalculator.Services.Tests
{
    public class TaxCalculationServiceTests
    {
        private readonly ITaxCalculationService _taxCalculationService;
        private TaxRule taxRule1 = new TaxRule()
        {
            Name = "Income Tax",
            Percent = 10,
            MinThreshold = 1000,
            MaxThreshold = null
        };
        private TaxRule taxRule2 = new TaxRule()
        {
            Name = "Social Tax",
            Percent = 15,
            MinThreshold = 1000,
            MaxThreshold = 3000
        };

        private IList<DeductionRule> deductionRules = new List<DeductionRule>() {
                    new DeductionRule() {
                        Name = "CharitySpent",
                        MaxPercentThreshold = 10
                    }
                 };

        public TaxCalculationServiceTests()
        {
            _taxCalculationService = new TaxCalculationService();
        }

        [Theory]
        [InlineData(1000.00, 0.00)]
        [InlineData(100.00, 0.00)]
        [InlineData(500.00, 0.00)]
        public void CalculateTaxTotalTaxShouldBeZero(decimal gross, decimal expected)
        {
            var taxPayer = new TaxPayerModel("Test", "12345", gross, new List<Deductable>());
            var result = _taxCalculationService.CalculateTax(taxPayer, new List<TaxRule>() {
                    taxRule1,
                    taxRule2
                 }, deductionRules);

            Assert.Equal(expected, result.TotalTax);
        }

        [Theory]
        [InlineData(1500.00, 50.00)]
        [InlineData(2570.80, 157.08)]
        [InlineData(3560.50, 256.05)]
        [InlineData(5500.00, 450.00)]
        public void CalculateTaxTotalTaxTestBasedOnTaxRule1(decimal gross, decimal expected)
        {
            var taxPayer = new TaxPayerModel("Test", "12345", gross, new List<Deductable>());
            var result = _taxCalculationService.CalculateTax(taxPayer, new List<TaxRule>() {
                    taxRule1
                 }, deductionRules);

            Assert.Equal(expected, result.TotalTax);
        }

        [Theory]
        [InlineData(1500.00, 75.00)]
        [InlineData(2500.00, 225.00)]
        [InlineData(2930.60, 289.59)]
        [InlineData(3500.00, 300.00)]
        [InlineData(5520.40, 300.00)]
        public void CalculateTaxTotalTaxTestBasedOnTaxRule2(decimal gross, decimal expected)
        {
            var taxPayer = new TaxPayerModel("Test", "12345", gross, new List<Deductable>());
            var result = _taxCalculationService.CalculateTax(taxPayer, new List<TaxRule>() {
                    taxRule2
                 }, deductionRules);

            Assert.Equal(expected, result.TotalTax);
        }

        [Theory]
        [InlineData(1500.00, 125.00)]
        [InlineData(1567.60, 141.90)]
        [InlineData(2500.00, 375.00)]
        [InlineData(3500.00, 550.00)]
        [InlineData(3678.50, 567.85)]
        [InlineData(4500.00, 650.00)]
        [InlineData(5500.00, 750.00)]
        [InlineData(5432.20, 743.22)]
        public void CalculateTaxTotalTaxBasedOnBothTaxRules(decimal gross, decimal expected)
        {
            var taxPayer = new TaxPayerModel("Test", "12345", gross, new List<Deductable>());
            var result = _taxCalculationService.CalculateTax(taxPayer, new List<TaxRule>() {
                    taxRule1,
                    taxRule2
                 }, deductionRules);

            Assert.Equal(expected, result.TotalTax);
        }

        [Theory]
        [InlineData(1500.00, 100.00, 100.00)]
        [InlineData(2570.80, 50.00, 380.20)]
        [InlineData(2500.00, 150.00, 337.50)]
        [InlineData(3560.50, 200.00, 536.05)]
        [InlineData(5500.00, 100.00, 740.00)]
        [InlineData(3600.00, 520.00, 524.00)]
        public void CalculateTaxTotalTaxTestBasedOnTaxRulesAndCharityDeduction(decimal gross, decimal charitySpent, decimal expected)
        {
            var taxPayer = new TaxPayerModel("Test", "12345", gross, new List<Deductable>() { new Deductable() { Name = "CharitySpent", Amount = charitySpent } });
            var result = _taxCalculationService.CalculateTax(taxPayer, new List<TaxRule>() {
                    taxRule1,
                    taxRule2
                 }, deductionRules);

            Assert.Equal(expected, result.TotalTax);
        }

        [Theory]
        [InlineData(1500.00, 100.00, 1400.00)]
        [InlineData(2570.80, 50.00, 2190.60)]
        [InlineData(2500.00, 150.00, 2162.50)]
        [InlineData(3560.50, 200.00, 3024.45)]
        [InlineData(3600.00, 520.00, 3076.00)]
        public void CalculateTaxNetIncomeBasedOnTaxRulesAndCharityDeduction(decimal gross, decimal charitySpent, decimal expected)
        {
            var taxPayer = new TaxPayerModel("Test", "12345", gross, new List<Deductable>() { new Deductable() { Name = "CharitySpent", Amount = charitySpent } });
            var result = _taxCalculationService.CalculateTax(taxPayer, new List<TaxRule>() {
                    taxRule1,
                    taxRule2
                 }, deductionRules);

            Assert.Equal(expected, result.NetIncome);
        }

        [Theory]
        [InlineData(2500.00, 150.00, 150.00)]
        [InlineData(3560.50, 200.00, 200.00)]
        [InlineData(3600.00, 520.00, 360.00)]
        public void CalculateTaxTotalDeductionsBasedOnTaxRule1AndCharityDeduction(decimal gross, decimal charitySpent, decimal expected)
        {
            var taxPayer = new TaxPayerModel("Test", "12345", gross, new List<Deductable>() { new Deductable() { Name = "CharitySpent", Amount = charitySpent } });
            var result = _taxCalculationService.CalculateTax(taxPayer, new List<TaxRule>() {
                    taxRule1,
                    taxRule2
                 }, deductionRules);

            Assert.Equal(expected, result.TotalDeductions);
        }
    }
}
