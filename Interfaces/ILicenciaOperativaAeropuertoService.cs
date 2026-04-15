using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ILicenciaOperativaAeropuertoService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(LicenciasOperativasAeropuerto modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, LicenciasOperativasAeropuerto modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<LicenciasOperativasAeropuerto>> ListarTodo();

        // Buscar por ID específico
        Task<LicenciasOperativasAeropuerto?> ObtenerPorId(int id);
    }
}



