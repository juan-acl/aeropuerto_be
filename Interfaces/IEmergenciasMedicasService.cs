using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEmergenciasMedicasService
    {
        Task<bool> Insertar(EmergenciasMedicasModel modelo);
        Task<List<EmergenciasMedicasModel>> ListarPorPasajero(int idPasajero);
        Task<List<EmergenciasMedicasModel>> ListarPorVuelo(int idVuelo);
        Task<bool> ActualizarAlta(int id, DateTime fechaAlta);
        Task<bool> EliminarFisico(int id);
    }
}