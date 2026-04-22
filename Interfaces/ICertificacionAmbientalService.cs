using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICertificacionAmbientalService
    {
        Task<List<CertificacionesAmbientalesAeropuerto>> ListarTodo();
        Task<CertificacionesAmbientalesAeropuerto?> ObtenerPorId(int id);
        Task<bool> Insertar(CertificacionesAmbientalesAeropuerto modelo);
        Task<bool> Actualizar(int id, CertificacionesAmbientalesAeropuerto modelo);
        Task<bool> Eliminar(int id);
    }
}
