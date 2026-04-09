using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEstacionamientoService
    {
        Task<bool> RegistrarEspacio(EstacionamientoModel modelo);
        Task<List<EstacionamientoModel>> ListarPorAeropuerto(string codigoAeropuerto);
        Task<List<EstacionamientoModel>> ListarDisponiblesPorTipo(string codigoAeropuerto, string tipoEspacio);
        Task<bool> CambiarDisponibilidad(int idEstacionamiento, int disponible);
        Task<bool> EliminarFisico(int id);
    }
}