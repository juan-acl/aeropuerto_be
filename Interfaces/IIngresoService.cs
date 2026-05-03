using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIngresoService
    {
        Task<List<Ingreso>> ListarTodo();
        Task<bool> Insertar(Ingreso modelo);
        Task<Ingreso?> ObtenerPorId(int id);
        Task<bool> Actualizar(Ingreso modelo);
        Task<bool> Eliminar(int id);
    }
}