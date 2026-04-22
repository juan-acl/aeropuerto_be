using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICumplimientoNormativoService
    {
        Task<List<CumplimientoNormativo>> ListarTodo();
        Task<CumplimientoNormativo?> ObtenerPorId(int id);
        Task<bool> Insertar(CumplimientoNormativo modelo);
        Task<bool> Actualizar(int id, CumplimientoNormativo modelo);
        Task<bool> Eliminar(int id);
    }
}
