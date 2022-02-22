using System;
using System.Collections.Generic;
using System.Linq;
using TaxCalculator.Core.Contracts;
using TaxCalculator.Core.Models;

namespace TaxCalculator.Services
{
    public class TaxCalculationService : ITaxCalculationService
    {
        public ITaxes CalculateTax(ITaxPayerWithDeductables taxPayer, IEnumerable<ITaxRule> taxRules, IEnumerable<IDeductionRule> deductionRules)
        {
            var taxableAmount = CalculateTaxableAmount(taxPayer, deductionRules);
            var totalDeductions = taxPayer.GrossIncome - taxableAmount;
            var taxesApplied = CalculateTaxBasedOnRules(taxableAmount, taxRules);
            var totalTax = CalculateTotalTax(taxesApplied);
            var netIncome = taxPayer.GrossIncome - totalTax;

            return new TaxesModel(taxPayer.GrossIncome, totalTax, netIncome, totalDeductions, taxesApplied);
        }

        private IEnumerable<ITaxResult> CalculateTaxBasedOnRules(decimal taxableAmount, IEnumerable<ITaxRule> taxRules)
        {
            var taxes = new List<ITaxResult>();
            foreach (var taxRule in taxRules)
            {
                var taxBase = GetTaxBasePerRule(taxableAmount, taxRule);
                var taxAmount = CalculateAmountOnPercentage(taxBase, taxRule.Percent);
                taxes.Add(new TaxResultModel(taxRule.Name, taxAmount));
            }

            return taxes;
        }

        private decimal CalculateTaxableAmount(ITaxPayerWithDeductables taxPayer, IEnumerable<IDeductionRule> deductionRules)
        {
            var taxableAmount = taxPayer.GrossIncome;
            foreach (var deductionRule in deductionRules)
            {
                var deduction = taxPayer.Deductables.FirstOrDefault(x => x.Name == deductionRule.Name);
                if (deduction != null)
                {
                    var thresholdDeductionAmount = CalculateAmountOnPercentage(taxPayer.GrossIncome, deductionRule.MaxPercentThreshold);
                    taxableAmount -= deduction.Amount > thresholdDeductionAmount ? thresholdDeductionAmount : deduction.Amount;
                }

            }

            return taxableAmount;
        }

        private decimal GetTaxBasePerRule(decimal taxableAmount, ITaxRule taxRule)
        {
            if (taxRule.MinThreshold.HasValue && taxRule.MaxThreshold.HasValue)
            {
                var amount = GetTaxBaseWithMaxThreshold(taxableAmount, taxRule.MaxThreshold.Value);
                return GetTaxBaseWithMinThreshold(amount, taxRule.MinThreshold.Value);
            }
            else if (taxRule.MinThreshold.HasValue)
            {
                return GetTaxBaseWithMinThreshold(taxableAmount, taxRule.MinThreshold.Value);
            }
            else if (taxRule.MaxThreshold.HasValue)
            {
                return GetTaxBaseWithMaxThreshold(taxableAmount, taxRule.MaxThreshold.Value);
            }

            return taxableAmount;
        }

        private decimal CalculateAmountOnPercentage(decimal amount, decimal percent)
        {
            if (percent < 0 || percent > 100)
            {
                throw new ArgumentOutOfRangeException("Percent out of range!");
            }

            return amount * (percent / 100);
        }

        private decimal GetTaxBaseWithMinThreshold(decimal gross, decimal minThreshold)
        {
            return gross < minThreshold ? 0 : gross - minThreshold;
        }

        private decimal GetTaxBaseWithMaxThreshold(decimal gross, decimal maxThreshold)
        {
            return gross > maxThreshold ? maxThreshold : gross;
        }

        private decimal CalculateTotalTax(IEnumerable<ITaxResult> taxesApplied)
        {
            var totalTax = 0m;
            foreach (var tax in taxesApplied)
            {
                totalTax += tax.Amount;
            }

            return totalTax;
        }
    }
}
