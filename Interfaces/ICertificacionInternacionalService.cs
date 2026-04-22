using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICertificacionInternacionalService
    {
        Task<List<CertificacionesInternacionales>> ListarTodo();
        Task<CertificacionesInternacionales?> ObtenerPorId(int id);
        Task<bool> Insertar(CertificacionesInternacionales modelo);
        Task<bool> Actualizar(int id, CertificacionesInternacionales modelo);
        Task<bool> Eliminar(int id);
    }
}
