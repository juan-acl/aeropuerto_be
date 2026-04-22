using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IVisitasSeguridadService
    {
        Task<List<VisitasSeguridadModel>> ListarTodo();
        Task<VisitasSeguridadModel?> ObtenerPorId(int id);
        Task<bool> Insertar(VisitasSeguridadModel modelo);
        Task<bool> Actualizar(int id, VisitasSeguridadModel modelo);
        Task<bool> Eliminar(int id);
    }
}
