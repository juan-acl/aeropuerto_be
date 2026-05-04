namespace Aeropuerto.Backend.Models
{
    public class CrearReservaRequest
    {
        public int IdVuelo { get; set; }
        public int IdPasajero { get; set; }
        public string ClaseServicio { get; set; } = null!;
        public string NumeroAsiento { get; set; } = null!;
        public string TipoTarifa { get; set; } = null!;
        public decimal Precio { get; set; }
        public string Moneda { get; set; } = null!;
    }
}
