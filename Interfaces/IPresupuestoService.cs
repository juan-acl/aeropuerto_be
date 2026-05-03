using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPresupuestoService
    {
        Task<List<Presupuesto>> ListarTodo();
        Task<bool> Insertar(Presupuesto modelo);
        Task<Presupuesto?> ObtenerPorId(int id);
        Task<bool> Actualizar(Presupuesto modelo);
        Task<bool> Eliminar(int id);
    }
}