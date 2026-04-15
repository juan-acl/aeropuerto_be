using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface ICondicionMeteorologicaService
    {
        Task<List<CondicionMeteorologicaModel>> ListarTodo();
        Task<CondicionMeteorologicaModel?> ObtenerPorId(int id);
        Task<bool> Insertar(CondicionMeteorologicaModel modelo);
        Task<bool> Actualizar(int id, CondicionMeteorologicaModel modelo);
        Task<bool> Eliminar(int id);
    }
}
