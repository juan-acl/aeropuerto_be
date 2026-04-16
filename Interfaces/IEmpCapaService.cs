using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEmpCapaService
    {
        Task<List<EmpleadoCapacitacion>> ListarTodo();
        Task<bool> Insertar(EmpleadoCapacitacion modelo);
    }
}