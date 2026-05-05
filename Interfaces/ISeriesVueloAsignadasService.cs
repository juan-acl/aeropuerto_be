using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISeriesVueloAsignadasService
    {
        Task<List<SeriesVueloAsignadas>> ListarTodo();
        Task<SeriesVueloAsignadas ?> ObtenerPorId(int id);
        Task<bool> Insertar(SeriesVueloAsignadas m);
        Task<bool> Actualizar(int id, SeriesVueloAsignadas m);
        Task<bool> Eliminar(int id);
    }
}