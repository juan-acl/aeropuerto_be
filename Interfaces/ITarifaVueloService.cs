using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface ITarifaVueloService
    {
        Task<List<TarifaVueloModel>> ListarTodo();
        Task<TarifaVueloModel?> ObtenerPorId(int id);
        Task<bool> Insertar(TarifaVueloModel modelo);
        Task<bool> Actualizar(int id, TarifaVueloModel modelo);
        Task<bool> Eliminar(int id);
    }
}
