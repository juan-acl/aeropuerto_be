using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEncuestasSatisfaccionService
    {
        Task<List<EncuestasSatisfaccionModel>> ListarTodo();
        Task<EncuestasSatisfaccionModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(EncuestasSatisfaccionModel m);
        Task<bool> Actualizar(int id, EncuestasSatisfaccionModel m);
        Task<bool> Eliminar(int id);
    }
}