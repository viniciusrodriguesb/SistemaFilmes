using FilmProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmProject.Controllers
{
    public class AvaliacaoController : Controller
    {
        private readonly AvaliacaoService _avaliacaoService;

        public AvaliacaoController(
            AvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpGet("listar-tipo-avaliacao")]
        public async Task<ActionResult> ListarTiposAvaliacao()
        {
            var result = await _avaliacaoService.ListarTiposAvaliacao();

            if (result is not null)
                return StatusCode(200, result);
            else
                return StatusCode(500);
        }

    }
}
