using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEmergenciasMedicasService
    {
        Task<List<EmergenciasMedicasModel>> ListarTodo();
        Task<EmergenciasMedicasModel?> ObtenerPorId(int id);
        Task<bool> Insertar(EmergenciasMedicasModel modelo);
        Task<bool> Actualizar(int id, EmergenciasMedicasModel modelo);
        Task<bool> Eliminar(int id);
    }
}
