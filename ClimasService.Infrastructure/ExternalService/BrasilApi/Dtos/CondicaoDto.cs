﻿namespace ClimasService.Infrastructure.ExternalService.BrasilApi.Dtos
{
    public class CondicaoDto
    {
        public string data { get; set; }
        public string condicao { get; set; }
        public string condicao_desc { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public int indice_uv { get; set; }
    }
}
