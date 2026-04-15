using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISurtidorCombustibleService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(SurtidoresCombustible modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, SurtidoresCombustible modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<SurtidoresCombustible>> ListarTodo();

        // Buscar por ID específico
        Task<SurtidoresCombustible?> ObtenerPorId(int id);
    }
}


