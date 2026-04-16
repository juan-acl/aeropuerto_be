using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IObjetosDecomisadosService
    {
        Task<bool> RegistrarDecomiso(ObjetosDecomisadosModel modelo);
        Task<List<ObjetosDecomisadosModel>> ListarPorControl(int idControl);
        Task<List<ObjetosDecomisadosModel>> ListarPorPasajero(int idPasajero);
        Task<bool> ActualizarDestino(int id, string nuevoDestino);
        Task<bool> EliminarFisico(int id);
    }
}