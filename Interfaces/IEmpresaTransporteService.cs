using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEmpresaTransporteService
    {
        Task<List<EmpresasTransporte>> ListarTodo();
        Task<EmpresasTransporte?> ObtenerPorId(int id);
        Task<bool> Insertar(EmpresasTransporte modelo);
        Task<bool> Actualizar(int id, EmpresasTransporte modelo);
        Task<bool> Eliminar(int id);
    }
}
