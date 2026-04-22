using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReporteOaciService
    {
        Task<List<ReportesOaci>> ListarTodo();
        Task<ReportesOaci?> ObtenerPorId(int id);
        Task<bool> Insertar(ReportesOaci modelo);
        Task<bool> Actualizar(int id, ReportesOaci modelo);
        Task<bool> Eliminar(int id);
    }
}
