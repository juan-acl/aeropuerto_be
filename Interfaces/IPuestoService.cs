using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPuestoService
    {
        Task<List<PuestoTrabajo>> ListarTodo();
        Task<bool> Insertar(PuestoTrabajo modelo);
        Task<PuestoTrabajo?> ObtenerPorId(int id);
        Task<bool> Actualizar(PuestoTrabajo modelo);
        Task<bool> Eliminar(int id);
    }
}