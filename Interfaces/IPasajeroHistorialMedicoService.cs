using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajeroHistorialMedicoService
    {
        Task<List<PasajeroHistorialMedicoModel>> ListarTodo();
        Task<PasajeroHistorialMedicoModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(PasajeroHistorialMedicoModel m);
        Task<bool> Actualizar(int id, PasajeroHistorialMedicoModel m);
        Task<bool> Eliminar(int id);
    }
}