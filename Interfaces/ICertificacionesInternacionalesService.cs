using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICertificacionesInternacionalesService
    {
        Task<List<CertificacionesInternacionales>> ListarTodo();
        Task<CertificacionesInternacionales ?> ObtenerPorId(int id);
        Task<bool> Insertar(CertificacionesInternacionales m);
        Task<bool> Actualizar(int id, CertificacionesInternacionales m);
        Task<bool> Eliminar(int id);
    }
}