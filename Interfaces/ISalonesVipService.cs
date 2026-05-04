using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISalonesVipService
    {
        Task<List<SalonesVipModel>> ListarTodo();
        Task<SalonesVipModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(SalonesVipModel m);
        Task<bool> Actualizar(int id, SalonesVipModel m);
        Task<bool> Eliminar(int id);
    }
}