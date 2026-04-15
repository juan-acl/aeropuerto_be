using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITarifaTransporteTerrestreService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(TarifasTransporteTerrestre modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, TarifasTransporteTerrestre modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<TarifasTransporteTerrestre>> ListarTodo();

        // Buscar por ID específico
        Task<TarifasTransporteTerrestre?> ObtenerPorId(int id);
    }
}


