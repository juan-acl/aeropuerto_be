using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface INewsletterSuscripcionService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(NewsletterSuscripciones modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, NewsletterSuscripciones modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<NewsletterSuscripciones>> ListarTodo();

        // Buscar por ID específico
        Task<NewsletterSuscripciones?> ObtenerPorId(int id);
    }
}



