using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPresupuestoService
    {
        Task<List<Presupuesto>> ListarTodo();
        Task<Presupuesto ?> ObtenerPorId(int id);
        Task<bool> Insertar(Presupuesto m);
        Task<bool> Actualizar(int id, Presupuesto m);
        Task<bool> Eliminar(int id);
    }
}