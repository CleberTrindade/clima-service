using ClimasService.Infrastructure.ExternalService.BrasilApi.Dtos;

namespace ClimasService.Infrastructure.ExternalService.BrasilApi.Intefaces
{
    public interface IBrasilApiService
    {
        Task<ClimaResponse> ObterClimaCidadeAsync(int cityCode);
        Task<ClimaResponse> ObterClimaAeroportoAsync(string icaoCode);
    }
}
