using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEmpCapaService
    {
        Task<List<EmpleadoCapacitacion>> ListarTodo();
        Task<bool> Insertar(EmpleadoCapacitacion modelo);
        Task<EmpleadoCapacitacion?> ObtenerPorId(int id);
        Task<bool> Actualizar(EmpleadoCapacitacion modelo);
        Task<bool> Eliminar(int id);
    }
}