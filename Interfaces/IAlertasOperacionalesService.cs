using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAlertasOperacionalesService
    {
        Task<List<AlertasOperacionales>> ListarTodo();
        Task<AlertasOperacionales ?> ObtenerPorId(int id);
        Task<bool> Insertar(AlertasOperacionales m);
        Task<bool> Actualizar(int id, AlertasOperacionales m);
        Task<bool> Eliminar(int id);
    }
}