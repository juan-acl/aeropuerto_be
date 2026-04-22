using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ILicenciaOperativaService
    {
        Task<List<LicenciasOperativasAeropuerto>> ListarTodo();
        Task<LicenciasOperativasAeropuerto?> ObtenerPorId(int id);
        Task<bool> Insertar(LicenciasOperativasAeropuerto modelo);
        Task<bool> Actualizar(int id, LicenciasOperativasAeropuerto modelo);
        Task<bool> Eliminar(int id);
    }
}
