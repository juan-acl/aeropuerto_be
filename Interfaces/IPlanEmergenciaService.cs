using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPlanEmergenciaService
    {
        Task<List<PlanesEmergencia>> ListarTodo();
        Task<PlanesEmergencia?> ObtenerPorId(int id);
        Task<bool> Insertar(PlanesEmergencia modelo);
        Task<bool> Actualizar(int id, PlanesEmergencia modelo);
        Task<bool> Eliminar(int id);
    }
}
