using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IActivacionesEmergenciaService
    {
        Task<List<ActivacionesEmergencia>> ListarTodo();
        Task<ActivacionesEmergencia ?> ObtenerPorId(int id);
        Task<bool> Insertar(ActivacionesEmergencia m);
        Task<bool> Actualizar(int id, ActivacionesEmergencia m);
        Task<bool> Eliminar(int id);
    }
}