using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISerieVueloService
    {
        Task<List<SeriesVueloAsignadas>> ListarTodo();
        Task<SeriesVueloAsignadas?> ObtenerPorId(int id);
        Task<bool> Insertar(SeriesVueloAsignadas modelo);
        Task<bool> Actualizar(int id, SeriesVueloAsignadas modelo);
        Task<bool> Eliminar(int id);
    }
}
