using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEncuestasPostVueloService
    {
        Task<List<EncuestasPostVuelo>> ListarTodo();
        Task<EncuestasPostVuelo ?> ObtenerPorId(int id);
        Task<bool> Insertar(EncuestasPostVuelo m);
        Task<bool> Actualizar(int id, EncuestasPostVuelo m);
        Task<bool> Eliminar(int id);
    }
}