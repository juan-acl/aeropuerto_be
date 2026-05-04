using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPuestoTrabajoService
    {
        Task<List<PuestoTrabajo>> ListarTodo();
        Task<PuestoTrabajo ?> ObtenerPorId(int id);
        Task<bool> Insertar(PuestoTrabajo m);
        Task<bool> Actualizar(int id, PuestoTrabajo m);
        Task<bool> Eliminar(int id);
    }
}