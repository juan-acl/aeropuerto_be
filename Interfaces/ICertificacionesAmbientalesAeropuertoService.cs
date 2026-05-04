using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICertificacionesAmbientalesAeropuertoService
    {
        Task<List<CertificacionesAmbientalesAeropuerto>> ListarTodo();
        Task<CertificacionesAmbientalesAeropuerto ?> ObtenerPorId(int id);
        Task<bool> Insertar(CertificacionesAmbientalesAeropuerto m);
        Task<bool> Actualizar(int id, CertificacionesAmbientalesAeropuerto m);
        Task<bool> Eliminar(int id);
    }
}