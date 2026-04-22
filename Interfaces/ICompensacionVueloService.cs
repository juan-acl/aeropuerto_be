using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICompensacionVueloService
    {
        Task<List<CompensacionesVuelo>> ListarTodo();
        Task<CompensacionesVuelo?> ObtenerPorId(int id);
        Task<bool> Insertar(CompensacionesVuelo modelo);
        Task<bool> Actualizar(int id, CompensacionesVuelo modelo);
        Task<bool> Eliminar(int id);
    }
}
