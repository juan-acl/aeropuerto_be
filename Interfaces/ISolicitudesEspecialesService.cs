using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISolicitudesEspecialesService
    {
        Task<List<SolicitudesEspecialesModel>> ListarTodo();
        Task<SolicitudesEspecialesModel?> ObtenerPorId(int id);
        Task<bool> Insertar(SolicitudesEspecialesModel modelo);
        Task<bool> Actualizar(int id, SolicitudesEspecialesModel modelo);
        Task<bool> Eliminar(int id);
    }
}
