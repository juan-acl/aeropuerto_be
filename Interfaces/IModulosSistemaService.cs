using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IModulosSistemaService
    {
        Task<List<ModulosSistema>> ListarTodo();
        Task<ModulosSistema ?> ObtenerPorId(int id);
        Task<bool> Insertar(ModulosSistema m);
        Task<bool> Actualizar(int id, ModulosSistema m);
        Task<bool> Eliminar(int id);
    }
}