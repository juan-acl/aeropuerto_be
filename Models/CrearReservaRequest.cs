namespace Aeropuerto.Backend.Models
{
    public class CrearReservaRequest
    {
        public int IdVuelo { get; set; }
        public int IdPasajero { get; set; }
        public string ClaseServicio { get; set; }
        public string NumeroAsiento { get; set; }
        public string TipoTarifa { get; set; }
        public decimal Precio { get; set; }
        public string Moneda { get; set; }
    }
}
