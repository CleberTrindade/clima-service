using ClimasService.Application.ExtenalService;
using Microsoft.AspNetCore.Mvc;

namespace ClimasService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClimaController : ControllerBase
    {
        private readonly ILogger<ClimaController> _logger;
        private readonly IClimaService _climaService;

        public ClimaController(ILogger<ClimaController> logger, IClimaService climaService)
        {
            _logger = logger;
            _climaService = climaService;
        }

        [HttpGet, Route("/api/obter-clima-cidade")]
        public async Task<IActionResult> ObterClimaCidade(int cidadeId)
        {
            var result = await _climaService.ObterClimaCidadeAsync(cidadeId);
            return Ok(result);
        }

        [HttpGet, Route("/api/obter-clima-aeroporto")]
        public async Task<IActionResult> ObterClimaAeroporto(string icaoCode)
        {
            var result = await _climaService.ObterClimaAeroportoAsync(icaoCode);
            return Ok(result);
        }
    }
}