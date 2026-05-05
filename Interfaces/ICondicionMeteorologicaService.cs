using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICondicionMeteorologicaService
    {
        Task<List<CondicionMeteorologicaModel>> ListarTodo();
        Task<CondicionMeteorologicaModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(CondicionMeteorologicaModel m);
        Task<bool> Actualizar(int id, CondicionMeteorologicaModel m);
        Task<bool> Eliminar(int id);
    }
}