using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IMonitoreoRuidoService
    {
        Task<List<MonitoreoRuido>> ListarTodo();
        Task<MonitoreoRuido ?> ObtenerPorId(int id);
        Task<bool> Insertar(MonitoreoRuido m);
        Task<bool> Actualizar(int id, MonitoreoRuido m);
        Task<bool> Eliminar(int id);
    }
}