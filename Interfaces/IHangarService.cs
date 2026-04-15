using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface IHangarService
    {
        Task<List<HangarModel>> ListarTodo();
        Task<HangarModel?> ObtenerPorId(int id);
        Task<bool> Insertar(HangarModel modelo);
        Task<bool> Actualizar(int id, HangarModel modelo);
        Task<bool> Eliminar(int id);
    }
}
