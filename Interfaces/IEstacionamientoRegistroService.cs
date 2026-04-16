using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEstacionamientoRegistroService
    {
        Task<int> RegistrarEntrada(EstacionamientoRegistroModel modelo);
        Task<EstacionamientoRegistroModel?> CalcularSalida(int idRegistro);
        Task<bool> ProcesarPago(int idRegistro, string metodoPago);
        Task<List<EstacionamientoRegistroModel>> ListarVehiculosActivos();
        Task<bool> EliminarFisico(int id);
    }
}