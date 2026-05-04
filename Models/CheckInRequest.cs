namespace Aeropuerto.Backend.Models
{
    public class CheckInRequest
    {
        public string CodigoReserva { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;
        public string NumeroAsiento { get; set; } = null!;
    }
}
