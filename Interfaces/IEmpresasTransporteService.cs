using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEmpresasTransporteService
    {
        Task<List<EmpresasTransporte>> ListarTodo();
        Task<EmpresasTransporte ?> ObtenerPorId(int id);
        Task<bool> Insertar(EmpresasTransporte m);
        Task<bool> Actualizar(int id, EmpresasTransporte m);
        Task<bool> Eliminar(int id);
    }
}