using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProveedorRepuestoService
    {
        Task<List<ProveedorRepuesto>> ListarTodo();
        Task<bool> Insertar(ProveedorRepuesto modelo);
        Task<ProveedorRepuesto?> ObtenerPorId(int id);
        Task<bool> Actualizar(ProveedorRepuesto modelo);
        Task<bool> Eliminar(int id);
    }
}