using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface ILogAccesoSistemaService
    {
        Task<List<LogsAccesoSistema>> ListarTodo();
        Task<LogsAccesoSistema?> ObtenerPorId(int id);
        Task<bool> Insertar(LogsAccesoSistema modelo);
        Task<bool> Actualizar(int id, LogsAccesoSistema modelo);
        Task<bool> Eliminar(int id);
    }
}
