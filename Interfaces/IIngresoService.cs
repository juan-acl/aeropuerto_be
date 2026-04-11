using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIngresoService
    {
        Task<List<Ingreso>> ListarTodo();
        Task<bool> Insertar(Ingreso modelo);
    }
}