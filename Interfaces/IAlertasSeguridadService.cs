using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAlertasSeguridadService
    {
        Task<List<AlertasSeguridadModel>> ListarTodo();
        Task<AlertasSeguridadModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(AlertasSeguridadModel m);
        Task<bool> Actualizar(int id, AlertasSeguridadModel m);
        Task<bool> Eliminar(int id);
    }
}