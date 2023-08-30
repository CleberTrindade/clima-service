using ClimasService.Application.Models;

namespace ClimasService.Application.ExtenalService
{
    public interface IClimaService
    {
        Task<BaseResponse> ObterClimaCidadeAsync(int cityCode);
        Task<BaseResponse> ObterClimaAeroportoAsync(string icaoCode);
    }
}
