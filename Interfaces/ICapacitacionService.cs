using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICapacitacionService
    {
        Task<List<Capacitacion>> ListarTodo();
        Task<bool> Insertar(Capacitacion modelo);
    }
}