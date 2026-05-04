using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajerosRedesSocialesService
    {
        Task<List<PasajerosRedesSocialesModel>> ListarTodo();
        Task<PasajerosRedesSocialesModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(PasajerosRedesSocialesModel m);
        Task<bool> Actualizar(int id, PasajerosRedesSocialesModel m);
        Task<bool> Eliminar(int id);
    }
}