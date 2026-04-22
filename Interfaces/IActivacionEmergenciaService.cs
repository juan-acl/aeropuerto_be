using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IActivacionEmergenciaService
    {
        Task<List<ActivacionesEmergencia>> ListarTodo();
        Task<ActivacionesEmergencia?> ObtenerPorId(int id);
        Task<bool> Insertar(ActivacionesEmergencia modelo);
        Task<bool> Actualizar(int id, ActivacionesEmergencia modelo);
        Task<bool> Eliminar(int id);
    }
}
