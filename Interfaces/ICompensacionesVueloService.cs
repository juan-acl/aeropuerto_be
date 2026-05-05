using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICompensacionesVueloService
    {
        Task<List<CompensacionesVuelo>> ListarTodo();
        Task<CompensacionesVuelo ?> ObtenerPorId(int id);
        Task<bool> Insertar(CompensacionesVuelo m);
        Task<bool> Actualizar(int id, CompensacionesVuelo m);
        Task<bool> Eliminar(int id);
    }
}