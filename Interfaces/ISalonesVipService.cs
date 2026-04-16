using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISalonesVipService
    {
        Task<bool> RegistrarSalon(SalonesVipModel modelo);
        Task<List<SalonesVipModel>> ListarPorAeropuerto(string codigoAeropuerto);
        Task<List<SalonesVipModel>> ListarActivos(string codigoAeropuerto);
        Task<bool> ActualizarCapacidad(int idSalon, int nuevaCapacidad);
        Task<bool> DesactivarSalon(int id);
        Task<bool> EliminarFisico(int id);
    }
}