using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IComunicacionesEmergenciaService
    {
        Task<List<ComunicacionesEmergencia>> ListarTodo();
        Task<ComunicacionesEmergencia ?> ObtenerPorId(int id);
        Task<bool> Insertar(ComunicacionesEmergencia m);
        Task<bool> Actualizar(int id, ComunicacionesEmergencia m);
        Task<bool> Eliminar(int id);
    }
}