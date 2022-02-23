using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxCalculator.Core.Models;
using TaxCalculator.Data.Repositories.Contracts;
using TaxCalculator.Services;
using TaxCalculator.WebApi.DTOs;
using System.Threading.Tasks;


namespace TaxCalculator.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly IMapper _mapper;
        private readonly ITaxCalculationService _taxCalculationService;
        private readonly ITaxRuleRepository _taxRuleRepository;
        private readonly IDeductionRuleRepository _deductionRuleRepository;

        public CalculatorController(ILogger<CalculatorController> logger,
                                    IMapper mapper,
                                    ITaxCalculationService taxCalculationService,
                                    ITaxRuleRepository taxRuleRepository,
                                    IDeductionRuleRepository deductionRuleRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _taxCalculationService = taxCalculationService;
            _taxRuleRepository = taxRuleRepository;
            _deductionRuleRepository = deductionRuleRepository;
        }

        [HttpPost("Calculate")]
        public async Task<IActionResult> Calculate(TaxPayerDTO taxPayerDTO)
        {
            var taxRules = await _taxRuleRepository.All();
            var deductionRules = await _deductionRuleRepository.All();
            var result = _taxCalculationService.CalculateTax(_mapper.Map<TaxPayerModel>(taxPayerDTO), taxRules, deductionRules);

            return Ok(result);
        }
    }
}
