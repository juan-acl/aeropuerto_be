using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPerfilViajeroService
    {
        Task<bool> Insertar(PerfilViajeroModel modelo);
        Task<PerfilViajeroModel?> ObtenerPorPasajero(int idPasajero);
        Task<bool> SumarPuntos(int idPerfil, int puntos);
        Task<bool> ActualizarCategoria(int idPerfil, string nuevaCategoria);
        Task<bool> Eliminar(int id);
    }
}