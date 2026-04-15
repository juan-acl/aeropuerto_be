using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProyectosEficienciaEnergeticaService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(ProyectosEficienciaEnergetica modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, ProyectosEficienciaEnergetica modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<ProyectosEficienciaEnergetica>> ListarTodo();

        // Buscar por ID específico
        Task<ProyectosEficienciaEnergetica?> ObtenerPorId(int id);
    }
}


