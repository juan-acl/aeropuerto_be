using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IMotorAvionService
    {
        Task<bool> Insertar(MotorAvionModel modelo);

        // Actualiza el nombre, tipo, empuje y estado por ID
        Task<bool> Actualizar(int id, string nombre, string tipo, decimal empuje, int activo);

        // Eliminación por ID único (PK NUMBER)
        Task<bool> Eliminar(int id);

        Task<List<MotorAvionModel>> ListarTodo();

        // Obtener un motor específico por su ID
        Task<MotorAvionModel?> ObtenerPorId(int id);
    }
}

