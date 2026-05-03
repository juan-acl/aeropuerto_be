using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICapacitacionService
    {
        Task<List<Capacitacion>> ListarTodo();
        Task<bool> Insertar(Capacitacion modelo);
        Task<Capacitacion?> ObtenerPorId(int id);
        Task<bool> Actualizar(Capacitacion modelo);
        Task<bool> Eliminar(int id);
    }
}