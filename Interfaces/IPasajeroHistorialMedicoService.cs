using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajeroHistorialMedicoService
    {
        Task<bool> Insertar(PasajeroHistorialMedicoModel modelo);
        Task<PasajeroHistorialMedicoModel?> ObtenerPorPasajero(int idPasajero);
        Task<bool> EliminarFisico(int idHistorial);
        Task<bool> ActualizarContactoEmergencia(int id, string nombre, string telefono);
    }
}