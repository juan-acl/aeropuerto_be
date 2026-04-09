using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAccesosAreasRestringidasService
    {
        Task<bool> RegistrarAcceso(AccesosAreasRestringidasModel modelo);
        Task<List<AccesosAreasRestringidasModel>> ListarPorEmpleado(int idEmpleado);
        Task<List<AccesosAreasRestringidasModel>> ListarAccesosDenegados();
        Task<bool> EliminarFisico(int id);
    }
}