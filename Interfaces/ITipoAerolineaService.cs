using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITipoAerolineaService
    {
        Task<List<TipoAerolineaModel>> ListarTodo();
        Task<TipoAerolineaModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(TipoAerolineaModel m);
        Task<bool> Actualizar(int id, TipoAerolineaModel m);
        Task<bool> Eliminar(int id);
    }
}