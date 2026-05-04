using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISeguridadControlesService
    {
        Task<List<SeguridadControlesModel>> ListarTodo();
        Task<SeguridadControlesModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(SeguridadControlesModel m);
        Task<bool> Actualizar(int id, SeguridadControlesModel m);
        Task<bool> Eliminar(int id);
    }
}