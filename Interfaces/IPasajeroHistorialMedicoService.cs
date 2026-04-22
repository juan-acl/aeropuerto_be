using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajeroHistorialMedicoService
    {
        Task<List<PasajeroHistorialMedicoModel>> ListarTodo();
        Task<PasajeroHistorialMedicoModel?> ObtenerPorId(int id);
        Task<bool> Insertar(PasajeroHistorialMedicoModel modelo);
        Task<bool> Actualizar(int id, PasajeroHistorialMedicoModel modelo);
        Task<bool> Eliminar(int id);
    }
}
