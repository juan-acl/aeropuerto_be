using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IOfertaPersonalizadaService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(OfertasPersonalizadas modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, OfertasPersonalizadas modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<OfertasPersonalizadas>> ListarTodo();

        // Buscar por ID específico
        Task<OfertasPersonalizadas?> ObtenerPorId(int id);
    }
}


