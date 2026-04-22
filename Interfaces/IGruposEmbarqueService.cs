using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IGruposEmbarqueService
    {
        Task<List<GruposEmbarqueModel>> ListarTodo();
        Task<GruposEmbarqueModel?> ObtenerPorId(int id);
        Task<bool> Insertar(GruposEmbarqueModel modelo);
        Task<bool> Actualizar(int id, GruposEmbarqueModel modelo);
        Task<bool> Eliminar(int id);
    }
}
