using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajerosRedesSocialesService
    {
        Task<bool> Insertar(PasajerosRedesSocialesModel modelo);
        Task<List<PasajerosRedesSocialesModel>> ListarPorPasajero(int idPasajero);
        Task<bool> Actualizar(int id, PasajerosRedesSocialesModel modelo);
        Task<bool> EliminarFisico(int id);
    }
}