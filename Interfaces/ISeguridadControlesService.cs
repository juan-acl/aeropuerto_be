using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISeguridadControlesService
    {
        Task<bool> RegistrarControl(SeguridadControlesModel modelo);
        Task<List<SeguridadControlesModel>> ListarPorAeropuerto(string codigo);
        Task<object> ObtenerResumenEstadistico(string codigo, DateTime fecha);
        Task<bool> EliminarFisico(int id);
    }
}