using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajerosSegmentosService
    {
        Task<List<PasajerosSegmentos>> ListarTodo();
        Task<PasajerosSegmentos ?> ObtenerPorId(int id);
        Task<bool> Insertar(PasajerosSegmentos m);
        Task<bool> Actualizar(int id, PasajerosSegmentos m);
        Task<bool> Eliminar(int id);
    }
}