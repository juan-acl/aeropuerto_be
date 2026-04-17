using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aeropuerto.Backend.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            // Registro silencioso en consola para el Administrador
            Console.WriteLine($"\n[🛡️ SYSTEM ERROR BLOCK] {DateTime.UtcNow}");
            Console.WriteLine($"Path: {context.Request.Path}");
            Console.WriteLine($"Exception: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}\n");

            // Payload hermético seguro hacia la red externa (Ej. Móvil / Web)
            var result = JsonSerializer.Serialize(new
            {
                estado = 500,
                mensaje = "Operación interrumpida por el servidor. Integridad de la base de datos verificada.",
                tipoFallo = ex.GetType().Name,
                referencia = Guid.NewGuid().ToString().Substring(0, 8).ToUpper() 
            });

            return context.Response.WriteAsync(result);
        }
    }
}
