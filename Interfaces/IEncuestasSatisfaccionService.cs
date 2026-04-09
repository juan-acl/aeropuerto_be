using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEncuestasSatisfaccionService
    {
        Task<int> RegistrarEncuesta(EncuestasSatisfaccionModel modelo);
        Task<List<EncuestasSatisfaccionModel>> ListarPorVuelo(int idVuelo);
        Task<object> ObtenerEstadisticasPorVuelo(int idVuelo);
        Task<bool> EliminarFisico(int id);
    }
}