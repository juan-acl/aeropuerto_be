using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIndicadoresDesempenoAmbientalService
    {
        Task<List<IndicadoresDesempenoAmbiental>> ListarTodo();
        Task<IndicadoresDesempenoAmbiental ?> ObtenerPorId(int id);
        Task<bool> Insertar(IndicadoresDesempenoAmbiental m);
        Task<bool> Actualizar(int id, IndicadoresDesempenoAmbiental m);
        Task<bool> Eliminar(int id);
    }
}