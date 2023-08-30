namespace ClimasService.Domain.Entities
{
    public class AeroportoClima
    {
        public string Codigo_Icao { get; set; }
        public DateTime Atualizado_Em { get; set; }
        public int Pressao_Atmosferica { get; set; }
        public string Visibilidade { get; set; }
        public int Vento { get; set; }
        public int Direcao_Vento { get; set; }
        public int Umidade { get; set; }
        public string Condicao { get; set; }
        public string Condicao_Desc { get; set; }
        public int Temperatura { get; set; }
    }
}
