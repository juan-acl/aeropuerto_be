namespace Aeropuerto.Backend.Models
{
    public class AsignarPuertaRequest
    {
        public int IdVuelo { get; set; }
        public int IdPuerta { get; set; }
        public string TipoVuelo { get; set; } = null!; // 'Nacional' o 'Internacional'
    }
}
