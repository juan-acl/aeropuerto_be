using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProgramaLealtadService
    {
        Task<int> RegistrarMembresia(ProgramaLealtadModel modelo);
        Task<ProgramaLealtadModel?> ObtenerPorPasajero(int idPasajero);
        Task<bool> SumarActividad(int idPasajero, int puntos, int millas);
        Task<bool> CanjearPuntos(int idPasajero, int puntosACanjear);
        Task<bool> EliminarFisico(int id);
    }
}