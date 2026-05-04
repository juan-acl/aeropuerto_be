using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IOrdenMantenimientoPredictivoService
    {
        Task<List<OrdenMantenimientoPredictivo>> ListarTodo();
        Task<OrdenMantenimientoPredictivo ?> ObtenerPorId(int id);
        Task<bool> Insertar(OrdenMantenimientoPredictivo m);
        Task<bool> Actualizar(int id, OrdenMantenimientoPredictivo m);
        Task<bool> Eliminar(int id);
    }
}