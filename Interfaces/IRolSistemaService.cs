using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRolSistemaService
    {
        Task<List<RolesSistema>> ListarTodo();
        Task<RolesSistema?> ObtenerPorId(int id);
        Task<bool> Insertar(RolesSistema modelo);
        Task<bool> Actualizar(int id, RolesSistema modelo);
        Task<bool> Eliminar(int id);
    }
}
