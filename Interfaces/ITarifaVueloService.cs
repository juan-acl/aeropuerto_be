using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITarifaVueloService
    {
        Task<List<TarifaVueloModel>> ListarTodo();
        Task<TarifaVueloModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(TarifaVueloModel m);
        Task<bool> Actualizar(int id, TarifaVueloModel m);
        Task<bool> Eliminar(int id);
    }
}