using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICertificacionesAmbientalesAeropuertoService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(CertificacionesAmbientalesAeropuerto modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, CertificacionesAmbientalesAeropuerto modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<CertificacionesAmbientalesAeropuerto>> ListarTodo();

        // Buscar por ID específico
        Task<CertificacionesAmbientalesAeropuerto?> ObtenerPorId(int id);
    }
}


