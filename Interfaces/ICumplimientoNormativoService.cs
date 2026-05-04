using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICumplimientoNormativoService
    {
        Task<List<CumplimientoNormativo>> ListarTodo();
        Task<CumplimientoNormativo ?> ObtenerPorId(int id);
        Task<bool> Insertar(CumplimientoNormativo m);
        Task<bool> Actualizar(int id, CumplimientoNormativo m);
        Task<bool> Eliminar(int id);
    }
}