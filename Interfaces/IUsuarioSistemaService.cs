using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IUsuarioSistemaService
    {
        Task<List<UsuariosSistema>> ListarTodo();
        Task<UsuariosSistema?> ObtenerPorId(int id);
        Task<bool> Insertar(UsuariosSistema modelo);
        Task<bool> Actualizar(int id, UsuariosSistema modelo);
        Task<bool> Eliminar(int id);
    }
}
