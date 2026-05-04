using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProhibicionesVueloService
    {
        Task<List<ProhibicionesVueloModel>> ListarTodo();
        Task<ProhibicionesVueloModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(ProhibicionesVueloModel m);
        Task<bool> Actualizar(int id, ProhibicionesVueloModel m);
        Task<bool> Eliminar(int id);
    }
}