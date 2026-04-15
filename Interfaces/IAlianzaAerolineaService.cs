using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAlianzaAerolineaService
    {
        Task<bool> Insertar(AlianzaAerolineaModel modelo);

        // Actualiza la sede, el conteo de miembros y la descripción por ID
        Task<bool> Actualizar(int id, string sede, int numeroMiembros, string descripcion);

        // Eliminación por ID (PK numérica)
        Task<bool> Eliminar(int id);

        Task<List<AlianzaAerolineaModel>> ListarTodo();

        // Método adicional para obtener una alianza específica
        Task<AlianzaAerolineaModel?> ObtenerPorId(int id);
    }
}

