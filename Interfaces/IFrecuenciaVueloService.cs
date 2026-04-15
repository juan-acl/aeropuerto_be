using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface IFrecuenciaVueloService
    {
        Task<List<FrecuenciaVueloModel>> ListarTodo();
        Task<FrecuenciaVueloModel?> ObtenerPorId(int id);
        Task<bool> Insertar(FrecuenciaVueloModel modelo);
        Task<bool> Actualizar(int id, FrecuenciaVueloModel modelo);
        Task<bool> Eliminar(int id);
    }
}
