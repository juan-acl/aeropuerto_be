using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAsignacionServiciosTransporteService
    {
        Task<List<AsignacionServiciosTransporte>> ListarTodo();
        Task<AsignacionServiciosTransporte ?> ObtenerPorId(int id);
        Task<bool> Insertar(AsignacionServiciosTransporte m);
        Task<bool> Actualizar(int id, AsignacionServiciosTransporte m);
        Task<bool> Eliminar(int id);
    }
}