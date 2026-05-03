using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITasaAplicadaService
    {
        Task<List<TasaAplicada>> ListarTodo();
        Task<bool> Insertar(TasaAplicada modelo);
        Task<TasaAplicada?> ObtenerPorId(int id);
        Task<bool> Actualizar(TasaAplicada modelo);
        Task<bool> Eliminar(int id);
    }
}