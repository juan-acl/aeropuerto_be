using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAeropuertoService
    {
        Task<bool> Insertar(AeropuertoModel modelo);
        Task<bool> Actualizar(string codigo, int terminales, int puertas, int activo);
        Task<bool> Eliminar(string codigo);

        Task<List<AeropuertoModel>> ListarTodo();
    }
}

