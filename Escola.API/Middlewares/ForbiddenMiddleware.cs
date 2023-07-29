using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace Escola.API.Middlewares
{
    public class ForbiddenMiddleware
    {

        private readonly RequestDelegate _next;
        public ForbiddenMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
            {
                context.Response.ContentType = "application/json";
                string message = "Acesso proibido. Esse usuario não possui permissão para acessar o conteúdo.";
                message = JsonConvert.SerializeObject(message);
                await context.Response.WriteAsync(message);
            }
        }

    }
}
