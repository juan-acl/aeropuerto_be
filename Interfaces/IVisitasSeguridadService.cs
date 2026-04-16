using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IVisitasSeguridadService
    {
        Task<bool> RegistrarIngreso(VisitasSeguridadModel modelo);
        Task<List<VisitasSeguridadModel>> ListarPorAeropuerto(string codigoAeropuerto);
        Task<List<VisitasSeguridadModel>> ListarVisitantesActivos(string codigoAeropuerto);
        Task<bool> RegistrarSalida(int id);
        Task<bool> EliminarFisico(int id);
    }
}