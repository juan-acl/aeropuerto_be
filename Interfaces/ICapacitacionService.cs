using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICapacitacionService
    {
        Task<List<Capacitacion>> ListarTodo();
        Task<Capacitacion ?> ObtenerPorId(int id);
        Task<bool> Insertar(Capacitacion m);
        Task<bool> Actualizar(int id, Capacitacion m);
        Task<bool> Eliminar(int id);
    }
}