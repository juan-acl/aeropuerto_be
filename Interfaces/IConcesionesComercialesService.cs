using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IConcesionesComercialesService
    {
        Task<List<ConcesionesComercialesModel>> ListarTodo();
        Task<ConcesionesComercialesModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(ConcesionesComercialesModel m);
        Task<bool> Actualizar(int id, ConcesionesComercialesModel m);
        Task<bool> Eliminar(int id);
    }
}