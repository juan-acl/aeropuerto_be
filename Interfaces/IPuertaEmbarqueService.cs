using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface IPuertaEmbarqueService
    {
        Task<List<PuertaEmbarqueModel>> ListarTodo();
        Task<PuertaEmbarqueModel?> ObtenerPorId(int id);
        Task<bool> Insertar(PuertaEmbarqueModel modelo);
        Task<bool> Actualizar(int id, PuertaEmbarqueModel modelo);
        Task<bool> Eliminar(int id);
    }
}
