namespace ClimasService.Domain.Entities
{
    public class CidadeClimas
    {
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime Atualizado_Em { get; set; }
        public List<CondicaoClima> Clima { get; set; }
    }
}
