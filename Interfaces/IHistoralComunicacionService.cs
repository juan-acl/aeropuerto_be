using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IHistorialComunicacionService
    {
        Task<bool> Insertar(HistorialComunicacionModel modelo);
        Task<List<HistorialComunicacionModel>> ListarPorPasajero(int idPasajero);
        Task<bool> Actualizar(int id, HistorialComunicacionModel modelo); 
        Task<bool> EliminarFisico(int id);
    }
}