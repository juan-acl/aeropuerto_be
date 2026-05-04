using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IFranquiciaEquipajeService
    {
        Task<List<FranquiciaEquipajeModel>> ListarTodo();
        Task<FranquiciaEquipajeModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(FranquiciaEquipajeModel m);
        Task<bool> Actualizar(int id, FranquiciaEquipajeModel m);
        Task<bool> Eliminar(int id);
    }
}