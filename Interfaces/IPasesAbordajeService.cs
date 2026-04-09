using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasesAbordajeService
    {
        Task<bool> GenerarPase(PasesAbordajeModel modelo);
        Task<PasesAbordajeModel?> ObtenerPorReserva(int idReserva);
        Task<bool> RegistrarUso(int idPase);
        Task<bool> EliminarFisico(int idPase);
    }
}