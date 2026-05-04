using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIngresoService
    {
        Task<List<Ingreso>> ListarTodo();
        Task<Ingreso ?> ObtenerPorId(int id);
        Task<bool> Insertar(Ingreso m);
        Task<bool> Actualizar(int id, Ingreso m);
        Task<bool> Eliminar(int id);
    }
}