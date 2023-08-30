
using AutoMapper;
using ClimasService.Domain.Entities;
using ClimasService.Infrastructure.ExternalService.BrasilApi.Dtos;

namespace ClimasService.Application.Mappers
{
    public class ClimaMapper : Profile
    {
        public ClimaMapper()
        {
            CreateMap<CidadeClimaDto, CidadeClimas>();
            CreateMap<AeroportoClimaDto, AeroportoClima>();
            CreateMap<CondicaoDto, CondicaoClima>();

        }
    }
}
