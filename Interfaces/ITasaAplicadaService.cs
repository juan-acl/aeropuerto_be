using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITasaAplicadaService
    {
        Task<List<TasaAplicada>> ListarTodo();
        Task<TasaAplicada ?> ObtenerPorId(int id);
        Task<bool> Insertar(TasaAplicada m);
        Task<bool> Actualizar(int id, TasaAplicada m);
        Task<bool> Eliminar(int id);
    }
}