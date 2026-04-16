using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAtencionEspecialService
    {
        Task<int> SolicitarAtencion(AtencionEspecialModel modelo);
        Task<bool> AsignarAsistente(int idAtencion, string nombreAsistente);
        Task<bool> FinalizarAtencion(int idAtencion, string? observaciones);
        Task<List<AtencionEspecialModel>> ListarPendientes();
        Task<List<AtencionEspecialModel>> ListarPorReserva(int idReserva);
        Task<bool> EliminarFisico(int id);
    }
}