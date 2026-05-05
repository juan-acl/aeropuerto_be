using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IHangarService
    {
        Task<List<HangarModel>> ListarTodo();
        Task<HangarModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(HangarModel m);
        Task<bool> Actualizar(int id, HangarModel m);
        Task<bool> Eliminar(int id);
    }
}