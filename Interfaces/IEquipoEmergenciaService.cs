using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEquipoEmergenciaService
    {
        Task<List<EquiposEmergencia>> ListarTodo();
        Task<EquiposEmergencia?> ObtenerPorId(int id);
        Task<bool> Insertar(EquiposEmergencia modelo);
        Task<bool> Actualizar(int id, EquiposEmergencia modelo);
        Task<bool> Eliminar(int id);
    }
}
