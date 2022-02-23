using AutoMapper;
using TaxCalculator.Core.Models;
using TaxCalculator.WebApi.DTOs;

namespace TaxCalculator.WebApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DeductableDTO, DeductableModel>();
            CreateMap<TaxPayerDTO, TaxPayerModel>();
        }
    }
}