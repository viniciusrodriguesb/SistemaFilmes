using FilmProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        #region Constructor
        private readonly TokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AuthenticationController(TokenService tokenService,
                                        IConfiguration configuration)
        {
            _tokenService = tokenService;
            _configuration = configuration;
        }
        #endregion

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha)
        {
            var token =  _tokenService.GenerateToken(email, senha);
            return Ok(new { token });
        }
    }
}
