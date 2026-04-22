using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface INewsletterSuscripcionService
    {
        Task<List<NewsletterSuscripciones>> ListarTodo();
        Task<NewsletterSuscripciones?> ObtenerPorId(int id);
        Task<bool> Insertar(NewsletterSuscripciones modelo);
        Task<bool> Actualizar(int id, NewsletterSuscripciones modelo);
        Task<bool> Eliminar(int id);
    }
}
