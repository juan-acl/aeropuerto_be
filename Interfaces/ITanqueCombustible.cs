using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITanqueCombustible
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(TanquesCombustible modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, TanquesCombustible modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<TanquesCombustible>> ListarTodo();

        // Buscar por ID específico
        Task<TanquesCombustible?> ObtenerPorId(int id);
    }
}
