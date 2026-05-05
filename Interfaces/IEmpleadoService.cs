using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEmpleadoService
    {
        Task<List<Empleado>> ListarTodo();
        Task<Empleado ?> ObtenerPorId(int id);
        Task<bool> Insertar(Empleado m);
        Task<bool> Actualizar(int id, Empleado m);
        Task<bool> Eliminar(int id);
    }
}