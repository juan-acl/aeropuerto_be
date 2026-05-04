using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEmergenciasMedicasService
    {
        Task<List<EmergenciasMedicasModel>> ListarTodo();
        Task<EmergenciasMedicasModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(EmergenciasMedicasModel m);
        Task<bool> Actualizar(int id, EmergenciasMedicasModel m);
        Task<bool> Eliminar(int id);
    }
}