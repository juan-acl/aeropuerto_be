using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICheckinDigitalService
    {
        Task<List<CheckinDigitalModel>> ListarTodo();
        Task<CheckinDigitalModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(CheckinDigitalModel m);
        Task<bool> Actualizar(int id, CheckinDigitalModel m);
        Task<bool> Eliminar(int id);
    }
}