using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IMonitoreoAireService
    {
        Task<List<MonitoreoAire>> ListarTodo();
        Task<MonitoreoAire ?> ObtenerPorId(int id);
        Task<bool> Insertar(MonitoreoAire m);
        Task<bool> Actualizar(int id, MonitoreoAire m);
        Task<bool> Eliminar(int id);
    }
}