using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IGruposEmbarqueService
    {
        Task<List<GruposEmbarqueModel>> ListarTodo();
        Task<GruposEmbarqueModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(GruposEmbarqueModel m);
        Task<bool> Actualizar(int id, GruposEmbarqueModel m);
        Task<bool> Eliminar(int id);
    }
}