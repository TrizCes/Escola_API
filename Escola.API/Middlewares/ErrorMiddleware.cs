using Escola.API.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.Net;
using Newtonsoft.Json;

namespace Escola.API.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await FormatarExcecao(context, ex);
            }

        }

        private static Task FormatarExcecao(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            string message = "Ocorreu um erro, tente novamente mais tarde";
            
            switch (ex)
            {
                case RegistroDuplicadoException:
                    message = ex.Message;                   
                    break;
                case ArgumentException:
                    message = ex.Message;              
                    break;
                case NotFoundException:
                    message = ex.Message;
                    break;
                case NotaInvalidaException:
                    message = ex.Message;
                    break;
            }
            message = JsonConvert.SerializeObject(message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(message);
        }
    }
}
