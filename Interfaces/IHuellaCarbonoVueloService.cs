using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IHuellaCarbonoVueloService
    {
        Task<List<HuellaCarbonoVuelo>> ListarTodo();
        Task<HuellaCarbonoVuelo ?> ObtenerPorId(int id);
        Task<bool> Insertar(HuellaCarbonoVuelo m);
        Task<bool> Actualizar(int id, HuellaCarbonoVuelo m);
        Task<bool> Eliminar(int id);
    }
}