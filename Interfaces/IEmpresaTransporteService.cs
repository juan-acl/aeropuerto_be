using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEmpresaTransporteService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(EmpresasTransporte modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, EmpresasTransporte modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<EmpresasTransporte>> ListarTodo();

        // Buscar por ID específico
        Task<EmpresasTransporte?> ObtenerPorId(int id);
    }
}



