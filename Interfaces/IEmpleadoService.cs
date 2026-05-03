using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEmpleadoService
    {
        Task<List<Empleado>> ListarTodo();
        Task<bool> Insertar(Empleado modelo);
        Task<Empleado?> ObtenerPorId(int id);
        Task<bool> Actualizar(Empleado modelo);
        Task<bool> Eliminar(int id);
    }
}