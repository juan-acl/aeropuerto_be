using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IVueloService
    {
        Task<List<VueloModel>> ListarTodo();
        Task<VueloModel?> ObtenerPorId(int id);
        Task<bool> Insertar(VueloModel m);
        Task<bool> Actualizar(int id, VueloModel m);
        Task<bool> Eliminar(int id);
    }
}
