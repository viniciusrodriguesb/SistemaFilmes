using FilmProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvaliacaoController : Controller
    {
        private readonly AvaliacaoService _avaliacaoService;

        public AvaliacaoController(
            AvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpGet("v1/media-avaliacao-filme")]
        public async Task<IActionResult> GerarMediaAvaliacoesPorFilme()
        {
            try
            {
                var result = await _avaliacaoService.GerarMediaAvaliacoesPorFilme();

                if(result is not null)
                    return StatusCode(200, result);

                return StatusCode(204, result);
            }catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}
