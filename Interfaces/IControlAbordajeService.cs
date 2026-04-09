using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IControlAbordajeService
    {
        Task<bool> RegistrarAbordaje(ControlAbordajeModel modelo);
        Task<List<ControlAbordajeModel>> ListarPorVuelo(int idVuelo);
        Task<int> ContarPasajerosAbordados(int idVuelo);
        Task<bool> EliminarFisico(int id);
    }
}