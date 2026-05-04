using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITipoAeropuertoService
    {
        Task<List<TipoAeropuertoModel>> ListarTodo();
        Task<TipoAeropuertoModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(TipoAeropuertoModel m);
        Task<bool> Actualizar(int id, TipoAeropuertoModel m);
        Task<bool> Eliminar(int id);
    }
}