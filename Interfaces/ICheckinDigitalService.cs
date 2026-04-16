using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICheckinDigitalService
    {
        Task<bool> RegistrarCheckin(CheckinDigitalModel modelo);
        Task<CheckinDigitalModel?> ObtenerPorReserva(int idReserva);
        Task<bool> ActualizarNotificaciones(int id, bool email, bool sms);
        Task<bool> EliminarFisico(int id);
    }
}