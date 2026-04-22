using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISalonesVipService
    {
        Task<List<SalonesVipModel>> ListarTodo();
        Task<SalonesVipModel?> ObtenerPorId(int id);
        Task<bool> Insertar(SalonesVipModel modelo);
        Task<bool> Actualizar(int id, SalonesVipModel modelo);
        Task<bool> Eliminar(int id);
    }
}
