using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICargaUbicacionService
    {
        Task<List<CargaUbicacion>> ListarTodo();
        Task<bool> Insertar(CargaUbicacion modelo);
        Task<CargaUbicacion?> ObtenerPorId(int id);
        Task<bool> Actualizar(CargaUbicacion modelo);
        Task<bool> Eliminar(int id);
    }
}