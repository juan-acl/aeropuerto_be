using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEntrenamientosEmergenciaService
    {
        Task<List<EntrenamientosEmergencia>> ListarTodo();
        Task<EntrenamientosEmergencia ?> ObtenerPorId(int id);
        Task<bool> Insertar(EntrenamientosEmergencia m);
        Task<bool> Actualizar(int id, EntrenamientosEmergencia m);
        Task<bool> Eliminar(int id);
    }
}