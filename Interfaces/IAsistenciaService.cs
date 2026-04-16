using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAsistenciaService
    {
        Task<List<Asistencia>> ListarTodo();
        Task<bool> Insertar(Asistencia modelo);
    }
}