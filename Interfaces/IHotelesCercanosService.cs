using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IHotelesCercanosService
    {
        Task<List<HotelesCercanosModel>> ListarTodo();
        Task<HotelesCercanosModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(HotelesCercanosModel m);
        Task<bool> Actualizar(int id, HotelesCercanosModel m);
        Task<bool> Eliminar(int id);
    }
}