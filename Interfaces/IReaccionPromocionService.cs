using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReaccionPromocionService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(ReaccionesPromociones modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, ReaccionesPromociones modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<ReaccionesPromociones>> ListarTodo();

        // Buscar por ID específico
        Task<ReaccionesPromociones?> ObtenerPorId(int id);
    }
}
