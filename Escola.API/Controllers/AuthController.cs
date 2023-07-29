using Escola.API.DTO;
using Escola.API.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("/logar")]
        [AllowAnonymous]
        public IActionResult Logar(LoginDTO loginDTO)
        {
            if (!_authService.Autenticar(loginDTO))
                return Unauthorized("Usuario ou Senha inválidos");

            string token = _authService.GerarToken(loginDTO);
            return Ok(token);

        }
    }
}
