namespace ClimasService.Domain.Entities
{
    public class CondicaoClima
    {
        public string Data { get; set; }
        public string Condicao { get; set; }
        public string Condicao_Desc { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int IndiceUV { get; set; }
    }
}
