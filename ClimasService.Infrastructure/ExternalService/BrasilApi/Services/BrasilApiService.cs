using ClimasService.Infrastructure.ExternalService.BrasilApi.Intefaces;
using ClimasService.Infrastructure.ExternalService.BrasilApi.Dtos;
using System.Text.Json;
using System.Net;

namespace ClimasService.Infrastructure.ExternalService.BrasilApi.Services
{
    public class BrasilApiService : IBrasilApiService
    {
        private string baseUrl = "https://brasilapi.com.br/api/cptec/v1/clima/";
        public BrasilApiService()
        {
        }

        public async Task<ClimaResponse> ObterClimaAeroportoAsync(string icaoCode)
        {
            HttpClient _httpClient = new HttpClient();
            AeroportoClimaDto clima = new AeroportoClimaDto();
            var climaResponse = new ClimaResponse();

            var response = await _httpClient.GetAsync($"{baseUrl}aeroporto/{icaoCode}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                clima = JsonSerializer.Deserialize<AeroportoClimaDto>(content);

                climaResponse.AddData(clima);
                return climaResponse;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                climaResponse.AddError(content, HttpStatusCode.NotFound);
            }
            return climaResponse;

            throw new NotImplementedException();
        }

        public async Task<ClimaResponse> ObterClimaCidadeAsync(int cityCode)
        {
            HttpClient _httpClient = new HttpClient();
            CidadeClimaDto clima = new CidadeClimaDto();
            var climaResponse = new ClimaResponse();

            var response = await _httpClient.GetAsync($"{baseUrl}previsao/{cityCode}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                clima = JsonSerializer.Deserialize<CidadeClimaDto>(content);

                climaResponse.AddData(clima);
                return climaResponse;
            }
            else {
                var content = await response.Content.ReadAsStringAsync();                
                climaResponse.AddError(content, HttpStatusCode.NotFound);
            }
            return climaResponse;
        }

    }
}
