using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITripulacionService
    {
        Task<bool> Insertar(TripulacionModel modelo);

        // Actualiza datos de contacto, tipo de tripulante, licencias y horas acumuladas por ID
        Task<bool> Actualizar(
            int id,
            string tipoTripulante,
            string licencia,
            DateTime vencimientoLicencia,
            decimal horasVuelo,
            int activo
        );

        // Eliminación por ID único (PK NUMBER)
        Task<bool> Eliminar(int id);

        Task<List<TripulacionModel>> ListarTodo();

        // Obtener un tripulante específico por su ID
        Task<TripulacionModel?> ObtenerPorId(int id);

        // Opcional: Buscar por número de documento (Unique en Oracle)
        Task<TripulacionModel?> ObtenerPorDocumento(string numeroDocumento);
    }
}

