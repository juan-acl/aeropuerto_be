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

            string mensajeFinal = "Operación interrumpida por el servidor.";
            string detalleFinal = ex.Message;

            // Manejo especial para errores de Oracle (RAISE_APPLICATION_ERROR)
            if (ex.InnerException is Oracle.ManagedDataAccess.Client.OracleException oex || ex is Oracle.ManagedDataAccess.Client.OracleException oex2)
            {
                var oracleEx = (ex as Oracle.ManagedDataAccess.Client.OracleException) ?? (ex.InnerException as Oracle.ManagedDataAccess.Client.OracleException);
                if (oracleEx != null)
                {
                    // Los errores de RAISE_APPLICATION_ERROR suelen estar en el rango -20000 a -20999
                    // o tienen un formato específico en el mensaje.
                    mensajeFinal = "Error de Base de Datos (Oracle)";
                    detalleFinal = oracleEx.Message;
                    
                    // Si el mensaje contiene el patrón ORA-20xxx, intentamos limpiar el ruido de Oracle
                    if (detalleFinal.Contains("ORA-"))
                    {
                        // Intentar extraer solo el texto después del código de error
                        var match = System.Text.RegularExpressions.Regex.Match(detalleFinal, @"ORA-\d+:\s*(.*)");
                        if (match.Success)
                        {
                            detalleFinal = match.Groups[1].Value.Split('\n')[0].Trim();
                        }
                    }
                }
            }

            Console.WriteLine($"\n[🛡️ SYSTEM ERROR BLOCK] {DateTime.UtcNow}");
            Console.WriteLine($"Path: {context.Request.Path}");
            Console.WriteLine($"Exception: {mensajeFinal}");
            Console.WriteLine($"Detalle: {detalleFinal}\n");

            var result = JsonSerializer.Serialize(new
            {
                estado = 500,
                mensaje = mensajeFinal,
                detalle = detalleFinal,
                tipoFallo = ex.GetType().Name,
                referencia = Guid.NewGuid().ToString().Substring(0, 8).ToUpper() 
            });

            return context.Response.WriteAsync(result);
        }
    }
}
