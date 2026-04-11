using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPuestoService
    {
        Task<List<PuestoTrabajo>> ListarTodo();
        Task<bool> Insertar(PuestoTrabajo modelo);
    }
}