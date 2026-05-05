using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPlanesEmergenciaService
    {
        Task<List<PlanesEmergencia>> ListarTodo();
        Task<PlanesEmergencia ?> ObtenerPorId(int id);
        Task<bool> Insertar(PlanesEmergencia m);
        Task<bool> Actualizar(int id, PlanesEmergencia m);
        Task<bool> Eliminar(int id);
    }
}