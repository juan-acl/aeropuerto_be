using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEntrenamientoEmergenciaService
    {
        Task<List<EntrenamientosEmergencia>> ListarTodo();
        Task<EntrenamientosEmergencia?> ObtenerPorId(int id);
        Task<bool> Insertar(EntrenamientosEmergencia modelo);
        Task<bool> Actualizar(int id, EntrenamientosEmergencia modelo);
        Task<bool> Eliminar(int id);
    }
}
