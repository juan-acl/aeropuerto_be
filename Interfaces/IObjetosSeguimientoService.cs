using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IObjetosSeguimientoService
    {
        Task<bool> RegistrarMovimiento(ObjetosSeguimientoModel modelo);
        Task<List<ObjetosSeguimientoModel>> ListarHistorialPorObjeto(int idObjeto);
        Task<bool> EliminarFisico(int id);
    }
}