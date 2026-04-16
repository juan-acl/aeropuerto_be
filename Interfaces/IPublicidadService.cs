using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPublicidadService
    {
        Task<int> RegistrarPublicidad(PublicidadModel modelo);
        Task<List<PublicidadModel>> ListarPorAeropuerto(string codigoAeropuerto);
        Task<List<PublicidadModel>> ListarActivas(string codigoAeropuerto);
        Task<bool> SubirContrato(int idPublicidad, byte[] documentoContrato);
        Task<byte[]?> ObtenerContrato(int idPublicidad);
        Task<bool> DesactivarPublicidad(int id);
        Task<bool> EliminarFisico(int id);
    }
}