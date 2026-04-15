using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface INewsletterEnvioService
    {
        Task<List<NewsletterEnvios>> ListarTodo();
        Task<NewsletterEnvios?> ObtenerPorId(int id);
        Task<bool> Insertar(NewsletterEnvios modelo);
        Task<bool> Actualizar(int id, NewsletterEnvios modelo);
        Task<bool> Eliminar(int id);
    }
}
