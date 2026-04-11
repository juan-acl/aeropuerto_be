using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPresupuestoService
    {
        Task<List<Presupuesto>> ListarTodo();
        Task<bool> Insertar(Presupuesto modelo);
    }
}