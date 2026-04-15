using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRecepcionCombustibleService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(RecepcionesCombustible modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, RecepcionesCombustible modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<RecepcionesCombustible>> ListarTodo();

        // Buscar por ID específico
        Task<RecepcionesCombustible?> ObtenerPorId(int id);
    }
}


