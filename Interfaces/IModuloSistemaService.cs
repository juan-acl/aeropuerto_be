using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IModuloSistemaService
    {
        Task<List<ModulosSistema>> ListarTodo();
        Task<ModulosSistema?> ObtenerPorId(int id);
        Task<bool> Insertar(ModulosSistema modelo);
        Task<bool> Actualizar(int id, ModulosSistema modelo);
        Task<bool> Eliminar(int id);
    }
}
