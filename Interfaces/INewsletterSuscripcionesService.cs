using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface INewsletterSuscripcionesService
    {
        Task<List<NewsletterSuscripciones>> ListarTodo();
        Task<NewsletterSuscripciones ?> ObtenerPorId(int id);
        Task<bool> Insertar(NewsletterSuscripciones m);
        Task<bool> Actualizar(int id, NewsletterSuscripciones m);
        Task<bool> Eliminar(int id);
    }
}