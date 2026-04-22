using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IHuellaCarbonoVueloService
    {
        Task<List<HuellaCarbonoVuelo>> ListarTodo();
        Task<HuellaCarbonoVuelo?> ObtenerPorId(int id);
        Task<bool> Insertar(HuellaCarbonoVuelo modelo);
        Task<bool> Actualizar(int id, HuellaCarbonoVuelo modelo);
        Task<bool> Eliminar(int id);
    }
}
