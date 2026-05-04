using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISolicitudesEspecialesService
    {
        Task<List<SolicitudesEspecialesModel>> ListarTodo();
        Task<SolicitudesEspecialesModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(SolicitudesEspecialesModel m);
        Task<bool> Actualizar(int id, SolicitudesEspecialesModel m);
        Task<bool> Eliminar(int id);
    }
}