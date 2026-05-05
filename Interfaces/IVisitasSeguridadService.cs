using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IVisitasSeguridadService
    {
        Task<List<VisitasSeguridadModel>> ListarTodo();
        Task<VisitasSeguridadModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(VisitasSeguridadModel m);
        Task<bool> Actualizar(int id, VisitasSeguridadModel m);
        Task<bool> Eliminar(int id);
    }
}