using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IOrdenMantenimientoPredictivoService
    {
        Task<List<OrdenMantenimientoPredictivo>> ListarTodo();
        Task<bool> Insertar(OrdenMantenimientoPredictivo modelo);
        Task<OrdenMantenimientoPredictivo?> ObtenerPorId(int id);
        Task<bool> Actualizar(OrdenMantenimientoPredictivo modelo);
        Task<bool> Eliminar(int id);
    }
}