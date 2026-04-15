using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRutaTransporteTerrestreService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(RutasTransporteTerrestre modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, RutasTransporteTerrestre modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<RutasTransporteTerrestre>> ListarTodo();

        // Buscar por ID específico
        Task<RutasTransporteTerrestre?> ObtenerPorId(int id);
    }
}


