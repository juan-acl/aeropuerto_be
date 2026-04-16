using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEmpleadoService
    {
        Task<List<Empleado>> ListarTodo();
        Task<bool> Insertar(Empleado modelo);
    }
}