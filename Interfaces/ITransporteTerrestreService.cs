using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITransporteTerrestreService
    {
        Task<bool> RegistrarTransporte(TransporteTerrestreModel modelo);
        Task<List<TransporteTerrestreModel>> ListarPorAeropuerto(string codigoAeropuerto);
        Task<List<TransporteTerrestreModel>> ListarActivos(string codigoAeropuerto, string? tipoTransporte = null);
        Task<bool> DesactivarTransporte(int id);
        Task<bool> EliminarFisico(int id);
    }
}