using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAsigPistasTiempoRealService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(AsignacionPistasTiempoReal modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, AsignacionPistasTiempoReal modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<AsignacionPistasTiempoReal>> ListarTodo();

        // Buscar por ID específico
        Task<AsignacionPistasTiempoReal?> ObtenerPorId(int id);
    }
}
