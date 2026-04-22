using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEncuestaPostVueloService
    {
        Task<List<EncuestasPostVuelo>> ListarTodo();
        Task<EncuestasPostVuelo?> ObtenerPorId(int id);
        Task<bool> Insertar(EncuestasPostVuelo modelo);
        Task<bool> Actualizar(int id, EncuestasPostVuelo modelo);
        Task<bool> Eliminar(int id);
    }
}
