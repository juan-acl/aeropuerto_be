using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReporteOaciService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(ReportesOaci modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, ReportesOaci modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<ReportesOaci>> ListarTodo();

        // Buscar por ID específico
        Task<ReportesOaci?> ObtenerPorId(int id);
    }
}
