using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReportesOaciService
    {
        Task<List<ReportesOaci>> ListarTodo();
        Task<ReportesOaci ?> ObtenerPorId(int id);
        Task<bool> Insertar(ReportesOaci m);
        Task<bool> Actualizar(int id, ReportesOaci m);
        Task<bool> Eliminar(int id);
    }
}