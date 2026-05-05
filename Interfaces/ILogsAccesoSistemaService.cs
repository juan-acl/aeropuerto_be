using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ILogsAccesoSistemaService
    {
        Task<List<LogsAccesoSistema>> ListarTodo();
        Task<LogsAccesoSistema ?> ObtenerPorId(int id);
        Task<bool> Insertar(LogsAccesoSistema m);
        Task<bool> Actualizar(int id, LogsAccesoSistema m);
        Task<bool> Eliminar(int id);
    }
}