using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProveedorRepuestoService
    {
        Task<List<ProveedorRepuesto>> ListarTodo();
        Task<ProveedorRepuesto ?> ObtenerPorId(int id);
        Task<bool> Insertar(ProveedorRepuesto m);
        Task<bool> Actualizar(int id, ProveedorRepuesto m);
        Task<bool> Eliminar(int id);
    }
}