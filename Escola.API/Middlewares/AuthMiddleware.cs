using Escola.API.DTO;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using Escola.API.Interfaces.Services;
using System.Linq;

namespace Escola.API.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAuthService _authService;
        public AuthMiddleware(RequestDelegate next, IAuthService autenticacao)
        {
            _authService = autenticacao;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!ValidateLogin(context))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            await _next(context);
        }

        private bool ValidateLogin(HttpContext context)
        {
            try
            {
                var header = context.Request.Headers.First(x => x.Key == "Authorization").Value.ToString();
                var base64 = header.Split(" ")[1];
                var loginSenhaByte = Convert.FromBase64String(base64);
                var loginSenha = System.Text.Encoding.UTF8.GetString(loginSenhaByte).Split(":");

                var loginDTO = new LoginDTO()
                {
                    Login = loginSenha[0],
                    Password = loginSenha[1]
                };

                return _authService.Autenticar(loginDTO);
            }
            catch
            {
                return false;
            }
        }
    }
}
