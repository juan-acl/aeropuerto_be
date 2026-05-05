using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ILicenciasOperativasAeropuertoService
    {
        Task<List<LicenciasOperativasAeropuerto>> ListarTodo();
        Task<LicenciasOperativasAeropuerto ?> ObtenerPorId(int id);
        Task<bool> Insertar(LicenciasOperativasAeropuerto m);
        Task<bool> Actualizar(int id, LicenciasOperativasAeropuerto m);
        Task<bool> Eliminar(int id);
    }
}