using FilmProject.DTO;
using FilmProject.DTO.UsuarioDTO;
using FilmProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmProject.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(
            UsuarioService usuarioService
            )
        {
            _usuarioService = usuarioService;
        }


        [HttpPost("v1/cadastrar")]
        public async Task<ActionResult<MensagemErroResponse>> CadastrarUsuario([FromBody] UsuarioRequest usuario)
        {
            try
            {
                var result = await _usuarioService.CadastrarUsuario(usuario);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("v1/listar")]
        public async Task<ActionResult<UsuarioResponse>> ListarUsuarios()
        {
            try
            {
                var lista = await _usuarioService.ListarUsuarios();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
