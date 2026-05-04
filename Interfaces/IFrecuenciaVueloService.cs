using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IFrecuenciaVueloService
    {
        Task<List<FrecuenciaVueloModel>> ListarTodo();
        Task<FrecuenciaVueloModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(FrecuenciaVueloModel m);
        Task<bool> Actualizar(int id, FrecuenciaVueloModel m);
        Task<bool> Eliminar(int id);
    }
}