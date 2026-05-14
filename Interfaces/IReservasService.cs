using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReservasService
    {
        Task<bool> Insertar(ReservasModel modelo);
        Task<List<ReservasModel>> ListarPorPasajero(int idPasajero);
        Task<List<ReservasModel>> ListarPorVuelo(int idVuelo);
        Task<ReservasModel?> ObtenerPorCodigo(string codigo);
        Task<bool> Actualizar(int id, ReservasModel modelo);
        Task<bool> EliminarFisico(int id);
        Task<bool> RegistrarAbordaje(EmbarqueRequest m);
        Task<bool> RealizarCheckIn(CheckInRequest request);
        Task<bool> RealizarCheckInMostrador(CheckInMostradorRequest request);
        Task<bool> CrearReserva(CrearReservaRequest request);
        Task<bool> PagarBoleto(PagoBoletoRequest request);
    }
}
