namespace ClimasService.Infrastructure.ExternalService.BrasilApi.Dtos
{
    public class CidadeClimaDto
    {
        public string cidade { get; set; }
        public string estado { get; set; }
        public DateTime atualizado_em { get; set; }
        public List<CondicaoDto> clima { get; set; }
    }
}
