using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IVueloService
    {
        Task<List<VueloModel>> ListarTodo();
        Task<VueloModel?> ObtenerPorId(int id);
        Task<List<VueloModel>> BuscarPorRuta(string origen, string destino, DateTime? fecha);
        Task<List<VueloModel>> ListarPorEstado(string estado);
        Task<bool> Insertar(VueloModel modelo);
        Task<bool> ActualizarEstado(int id, string estado, string? motivo);
        Task<bool> ActualizarHoraReal(int id, DateTime? horaSalidaReal, DateTime? horaLlegadaReal);
        Task<bool> Eliminar(int id);
    }
}
