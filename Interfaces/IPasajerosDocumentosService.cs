using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajerosDocumentosService
    {
        Task<List<PasajerosDocumentosModel>> ListarTodo();
        Task<PasajerosDocumentosModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(PasajerosDocumentosModel m);
        Task<bool> Actualizar(int id, PasajerosDocumentosModel m);
        Task<bool> Eliminar(int id);
    }
}