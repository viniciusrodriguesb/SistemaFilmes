using FilmProject.DTO;
using FilmProject.DTO.UsuarioDTO;
using FilmProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmProject.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
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
        public async Task<ActionResult<MensagemErroResponse>> CadastrarUsuario([FromBody] UsuarioRequest request)
        {
            try
            {
                var result = await _usuarioService.CadastrarUsuario(request);

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

        [HttpPut("v1/editar")]
        public async Task<ActionResult<UsuarioResponse>> EditarUsuario(UsuarioRequest request, int id)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Nome))
                {
                    return BadRequest();
                }

                var usuario = await _usuarioService.EditarUsuarios(request, id);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("v1/deletar")]
        public async Task<ActionResult> DeletarUsuario(int id)
        {
            try
            {
                var usuarioParaDeletar = await _usuarioService.DeletarUsuario(id);

                if (usuarioParaDeletar == false)
                {
                    return StatusCode(500);
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
