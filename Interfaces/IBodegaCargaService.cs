using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IBodegaCargaService
    {
        Task<List<BodegaCarga>> ListarTodo();
        Task<bool> Insertar(BodegaCarga modelo);
        Task<BodegaCarga?> ObtenerPorId(int id);
        Task<bool> Actualizar(BodegaCarga modelo);
        Task<bool> Eliminar(int id);
    }
}