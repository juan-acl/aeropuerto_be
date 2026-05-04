using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPuertaEmbarqueService
    {
        Task<List<PuertaEmbarqueModel>> ListarTodo();
        Task<PuertaEmbarqueModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(PuertaEmbarqueModel m);
        Task<bool> Actualizar(int id, PuertaEmbarqueModel m);
        Task<bool> Eliminar(int id);
    }
}