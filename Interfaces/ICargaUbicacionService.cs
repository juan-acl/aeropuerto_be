using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICargaUbicacionService
    {
        Task<List<CargaUbicacion>> ListarTodo();
        Task<CargaUbicacion ?> ObtenerPorId(int id);
        Task<bool> Insertar(CargaUbicacion m);
        Task<bool> Actualizar(int id, CargaUbicacion m);
        Task<bool> Eliminar(int id);
    }
}