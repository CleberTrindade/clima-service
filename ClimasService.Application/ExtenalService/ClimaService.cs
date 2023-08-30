using AutoMapper;
using ClimasService.Application.Models;
using ClimasService.Domain.Entities;
using ClimasService.Infrastructure.ExternalService.BrasilApi.Intefaces;

namespace ClimasService.Application.ExtenalService
{
    public class ClimaService : IClimaService
    {
        private readonly IBrasilApiService _brasilApiService;
        private readonly IMapper _mapper;

        public ClimaService(IBrasilApiService brasilApiService, IMapper mapper)
        {
            _brasilApiService = brasilApiService;
            _mapper = mapper;
        }

        public async Task<BaseResponse> ObterClimaAeroportoAsync(string icaoCode)
        {
            var clima = new BaseResponse();

            var retornoExtApi = await _brasilApiService.ObterClimaAeroportoAsync(icaoCode);

            if (retornoExtApi.Success)
            {
                clima.AddData(_mapper.Map<AeroportoClima>(retornoExtApi.Data));
            }
            else
            {
                clima.AddError(retornoExtApi.Errors);
                clima.SetStatusCode(retornoExtApi.StatusCode);
            }

            return clima;
        }

        public async Task<BaseResponse> ObterClimaCidadeAsync(int cidadeId)
        {
            var clima = new BaseResponse();

            var retornoExtApi = await _brasilApiService.ObterClimaCidadeAsync(cidadeId);

            if (retornoExtApi.Success)
            {
                clima.AddData(_mapper.Map<CidadeClimas>(retornoExtApi.Data));
            }
            else
            {
                clima.AddError(retornoExtApi.Errors);
                clima.SetStatusCode(retornoExtApi.StatusCode);
            }

            return clima;
        }
    }
}
