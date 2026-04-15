using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IQuejaTransporteTerrestreService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(QuejasTransporteTerrestre modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, QuejasTransporteTerrestre modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<QuejasTransporteTerrestre>> ListarTodo();

        // Buscar por ID específico
        Task<QuejasTransporteTerrestre?> ObtenerPorId(int id);
    }
}


