using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IHotelesCercanosService
    {
        Task<List<HotelesCercanosModel>> ListarTodo();
        Task<HotelesCercanosModel?> ObtenerPorId(int id);
        Task<bool> Insertar(HotelesCercanosModel modelo);
        Task<bool> Actualizar(int id, HotelesCercanosModel modelo);
        Task<bool> Eliminar(int id);
    }
}
