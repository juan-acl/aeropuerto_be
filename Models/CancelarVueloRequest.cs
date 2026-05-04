namespace Aeropuerto.Backend.Models
{
    public class CancelarVueloRequest
    {
        public int IdVuelo { get; set; }
        public string MotivoCancelacion { get; set; } = null!;
    }
}
