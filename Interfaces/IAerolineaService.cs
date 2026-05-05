using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAerolineaService
    {
        Task<List<AerolineaModel>> ListarTodo();
        Task<AerolineaModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(AerolineaModel m);
        Task<bool> Actualizar(int id, AerolineaModel m);
        Task<bool> Eliminar(int id);
    }
}