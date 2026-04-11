using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProveedorRepuestoService
    {
        Task<List<ProveedorRepuesto>> ListarTodo();
        Task<bool> Insertar(ProveedorRepuesto modelo);
    }
}