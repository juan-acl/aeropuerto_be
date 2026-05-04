using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPersonalEmergenciaService
    {
        Task<List<PersonalEmergencia>> ListarTodo();
        Task<PersonalEmergencia ?> ObtenerPorId(int id);
        Task<bool> Insertar(PersonalEmergencia m);
        Task<bool> Actualizar(int id, PersonalEmergencia m);
        Task<bool> Eliminar(int id);
    }
}