using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IGruposEmbarqueService
    {
        Task<bool> Insertar(GruposEmbarqueModel modelo);
        Task<List<GruposEmbarqueModel>> ListarPorVuelo(int idVuelo);
        Task<bool> Actualizar(int id, GruposEmbarqueModel modelo);
        Task<bool> EliminarFisico(int id);
    }
}