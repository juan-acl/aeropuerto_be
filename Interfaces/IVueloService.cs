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
        Task<bool> AsignarPuerta(AsignarPuertaRequest request);
        Task<bool> CancelarVuelo(CancelarVueloRequest request);
        Task<bool> CerrarEmbarque(int idVuelo);
        Task<bool> CrearVuelo(CrearVueloRequest request);
        Task<bool> ReprogramarVuelo(ReprogramarVueloRequest request);
    }
}
