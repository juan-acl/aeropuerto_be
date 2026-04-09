using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISalonesAccesosService
    {
        Task<int> RegistrarEntrada(SalonesAccesosModel modelo);
        Task<bool> RegistrarSalida(int idAcceso);
        Task<List<SalonesAccesosModel>> ListarAccesosActivos(int idSalon);
        Task<List<SalonesAccesosModel>> ListarHistorialPorSalon(int idSalon, DateTime fecha);
        Task<bool> EliminarFisico(int id);
    }
}