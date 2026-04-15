using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISerieVueloAsignadaService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(SeriesVueloAsignadas modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, SeriesVueloAsignadas modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<SeriesVueloAsignadas>> ListarTodo();

        // Buscar por ID específico
        Task<SeriesVueloAsignadas?> ObtenerPorId(int id);
    }
}


