using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajeroSegmentoService
    {
        Task<List<PasajerosSegmentos>> ListarTodo();
        Task<PasajerosSegmentos?> ObtenerPorId(int id);
        Task<bool> Insertar(PasajerosSegmentos modelo);
        Task<bool> Actualizar(int id, PasajerosSegmentos modelo);
        Task<bool> Eliminar(int id);
    }
}
