using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAsistenciaService
    {
        Task<List<Asistencia>> ListarTodo();
        Task<bool> Insertar(Asistencia modelo);
        Task<Asistencia?> ObtenerPorId(int id);
        Task<bool> Actualizar(Asistencia modelo);
        Task<bool> Eliminar(int id);
 
    }
}