using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IHistorialPrecioCombustibleService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(HistorialPreciosCombustible modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, HistorialPreciosCombustible modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<HistorialPreciosCombustible>> ListarTodo();

        // Buscar por ID específico
        Task<HistorialPreciosCombustible?> ObtenerPorId(int id);
    }
}



