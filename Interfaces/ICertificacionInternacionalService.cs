using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICertificacionInternacionalService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(CertificacionesInternacionales modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, CertificacionesInternacionales modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<CertificacionesInternacionales>> ListarTodo();

        // Buscar por ID específico
        Task<CertificacionesInternacionales?> ObtenerPorId(int id);
    }
}


