namespace Aeropuerto.Backend.Models
{
    public class EmbarqueRequest
    {
        public string CodigoReserva { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;
        public string PuertaEmbarque { get; set; } = null!;
    }
}
