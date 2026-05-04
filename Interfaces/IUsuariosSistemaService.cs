using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IUsuariosSistemaService
    {
        Task<List<UsuariosSistema>> ListarTodo();
        Task<UsuariosSistema ?> ObtenerPorId(int id);
        Task<bool> Insertar(UsuariosSistema m);
        Task<bool> Actualizar(int id, UsuariosSistema m);
        Task<bool> Eliminar(int id);
    }
}