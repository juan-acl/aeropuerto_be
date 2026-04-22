using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IConcesionesComercialesService
    {
        Task<List<ConcesionesComercialesModel>> ListarTodo();
        Task<ConcesionesComercialesModel?> ObtenerPorId(int id);
        Task<bool> Insertar(ConcesionesComercialesModel modelo);
        Task<bool> Actualizar(int id, ConcesionesComercialesModel modelo);
        Task<bool> Eliminar(int id);
    }
}
