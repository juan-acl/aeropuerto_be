using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITemporadaVueloService
    {
        Task<List<TemporadaVueloModel>> ListarTodo();
        Task<TemporadaVueloModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(TemporadaVueloModel m);
        Task<bool> Actualizar(int id, TemporadaVueloModel m);
        Task<bool> Eliminar(int id);
    }
}