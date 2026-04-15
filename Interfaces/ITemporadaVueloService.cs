using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITemporadaVueloService
    {
        Task<bool> Insertar(TemporadaVueloModel modelo);

        // Actualiza el nombre, rango de fechas, factor de demanda y estado por ID
        Task<bool> Actualizar(int id, string nombre, DateTime inicio, DateTime fin, decimal factor, int activa);

        // Eliminación por ID único (PK NUMBER)
        Task<bool> Eliminar(int id);

        Task<List<TemporadaVueloModel>> ListarTodo();

        // Obtener una temporada específica por su ID
        Task<TemporadaVueloModel?> ObtenerPorId(int id);
    }
}

