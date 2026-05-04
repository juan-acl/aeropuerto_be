using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISeguimientoCargaService
    {
        Task<List<SeguimientoCarga>> ListarTodo();
        Task<SeguimientoCarga ?> ObtenerPorId(int id);
        Task<bool> Insertar(SeguimientoCarga m);
        Task<bool> Actualizar(int id, SeguimientoCarga m);
        Task<bool> Eliminar(int id);
    }
}