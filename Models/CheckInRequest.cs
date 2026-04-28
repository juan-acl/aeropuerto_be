namespace Aeropuerto.Backend.Models
{
    public class CheckInRequest
    {
        public string CodigoReserva { get; set; }
        public string NumeroDocumento { get; set; }
        public string NumeroAsiento { get; set; }
    }
}
