using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAeropuertoService
    {
        Task<List<AeropuertoModel>> ListarTodo();
        Task<AeropuertoModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(AeropuertoModel m);
        Task<bool> Actualizar(int id, AeropuertoModel m);
        Task<bool> Eliminar(int id);
    }
}