using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPersonalEmergenciaService
    {
        Task<List<PersonalEmergencia>> ListarTodo();
        Task<PersonalEmergencia?> ObtenerPorId(int id);
        Task<bool> Insertar(PersonalEmergencia modelo);
        Task<bool> Actualizar(int id, PersonalEmergencia modelo);
        Task<bool> Eliminar(int id);
    }
}
