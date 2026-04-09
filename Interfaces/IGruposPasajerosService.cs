using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IGruposPasajerosService
    {
        Task<bool> AsignarPasajero(GruposPasajerosModel modelo);
        Task<List<GruposPasajerosModel>> ListarPasajerosPorGrupo(int idGrupo);
        Task<bool> EliminarRelacion(int idGrupo, int idPasajero);
    }
}