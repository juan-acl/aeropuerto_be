using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IBodegaCargaService
    {
        Task<List<BodegaCarga>> ListarTodo();
        Task<BodegaCarga ?> ObtenerPorId(int id);
        Task<bool> Insertar(BodegaCarga m);
        Task<bool> Actualizar(int id, BodegaCarga m);
        Task<bool> Eliminar(int id);
    }
}