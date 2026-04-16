using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajerosDocumentosService
    {
        Task<bool> Insertar(PasajerosDocumentosModel modelo);
        Task<List<PasajerosDocumentosModel>> ListarPorPasajero(int idPasajero);
        Task<bool> VerificarDocumento(int idDocumento, int estado);
        Task<bool> Eliminar(int id);
    }
}