using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAsignacionServicioService
    {
        Task<List<AsignacionServiciosTransporte>> ListarTodo();
        Task<AsignacionServiciosTransporte?> ObtenerPorId(int id);
        Task<bool> Insertar(AsignacionServiciosTransporte modelo);
        Task<bool> Actualizar(int id, AsignacionServiciosTransporte modelo);
        Task<bool> Eliminar(int id);
    }
}
