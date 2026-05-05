using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEquiposEmergenciaService
    {
        Task<List<EquiposEmergencia>> ListarTodo();
        Task<EquiposEmergencia ?> ObtenerPorId(int id);
        Task<bool> Insertar(EquiposEmergencia m);
        Task<bool> Actualizar(int id, EquiposEmergencia m);
        Task<bool> Eliminar(int id);
    }
}