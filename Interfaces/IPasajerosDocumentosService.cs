using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajerosDocumentosService
    {
        Task<List<PasajerosDocumentosModel>> ListarTodo();
        Task<PasajerosDocumentosModel?> ObtenerPorId(int id);
        Task<bool> Insertar(PasajerosDocumentosModel modelo);
        Task<bool> Actualizar(int id, PasajerosDocumentosModel modelo);
        Task<bool> Eliminar(int id);
    }
}
