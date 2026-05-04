using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAsistenciaService
    {
        Task<List<Asistencia>> ListarTodo();
        Task<Asistencia ?> ObtenerPorId(int id);
        Task<bool> Insertar(Asistencia m);
        Task<bool> Actualizar(int id, Asistencia m);
        Task<bool> Eliminar(int id);
    }
}