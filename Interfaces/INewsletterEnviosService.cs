using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface INewsletterEnviosService
    {
        Task<List<NewsletterEnvios>> ListarTodo();
        Task<NewsletterEnvios ?> ObtenerPorId(int id);
        Task<bool> Insertar(NewsletterEnvios m);
        Task<bool> Actualizar(int id, NewsletterEnvios m);
        Task<bool> Eliminar(int id);
    }
}